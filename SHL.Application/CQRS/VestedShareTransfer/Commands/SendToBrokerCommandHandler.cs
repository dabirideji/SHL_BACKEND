using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SHL.Application.DTO.VestedShareTransfer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using SHL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.VestedShareTransfer.Commands
{
    public record SendToBrokerCommand(SendToBrokerDto Dto) : IRequest<Stream>;
    class SendToBrokerCommandHandler : IRequestHandler<SendToBrokerCommand, Stream>
    {
        private readonly ILogger<SendToBrokerCommandHandler> logger;
        private readonly IValidator<SendToBrokerDto> validator;
        private readonly IVestedShareTransferRepository vestedShareTransferRepository;
        private readonly IBrokerRepository brokerRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IExcelProcessor excelProcessor;
        private readonly IOfferEmailChannel offerEmailChannel;
        private readonly IMailService mailService;
        private readonly IShareholderRepository shareholderRepository;
        private readonly ITransactionHistoryRepository transactionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public SendToBrokerCommandHandler(
            ILogger<SendToBrokerCommandHandler> logger,
            IValidator<SendToBrokerDto> validator,
            IVestedShareTransferRepository vestedShareTransferRepository,
            IBrokerRepository brokerRepository,
            IUserIdentityService userIdentityService,
            IExcelProcessor excelProcessor,
            IOfferEmailChannel offerEmailChannel,
            IMailService mailService,
            IShareholderRepository shareholderRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.validator = validator;
            this.vestedShareTransferRepository = vestedShareTransferRepository;
            this.brokerRepository = brokerRepository;
            this.userIdentityService = userIdentityService;
            this.excelProcessor = excelProcessor;
            this.offerEmailChannel = offerEmailChannel;
            this.mailService = mailService;
            this.shareholderRepository = shareholderRepository;
            this.transactionHistoryRepository = transactionHistoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Stream> Handle(SendToBrokerCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            //convert VestedSharedRequest to Excel
            var approvedRequests = vestedShareTransferRepository.Get(v => request.Dto.VestedSharedRequestIds.Contains(v.Id) && v.BrokerId == request.Dto.BrokerId && v.Status == Domain.Enums.VestesShareTransfer.Approve.ToString())
                .Select(n => new SendToBrokerModel
                {
                    ChnNumber = n.ChnNumber,
                    CscsNumber = n.CscsNumber,
                    HolderEmail = n.HolderEmailAddress,
                    HolderName = n.HolderName,
                    ReferenceNumber = n.ReferenceNumber,
                    Status = n.Status,
                    TransferValue = n.TransferValue
                }).ToList();


            var csvStream = await excelProcessor.ConvertToCsv(approvedRequests);

            //email file to broker
            var broker = await brokerRepository.GetByIdAsync(request.Dto.BrokerId);

            // csvStream.Position = 0;
            var stream = new MemoryStream(csvStream);
            var attachment = new Attachment(stream, "vestedsharedrequest.csv", "text/csv");
            await mailService.SendMailWithAttachmentAsync(broker!.EmailAddress, "Please find attached vested shared request", "Vested Share Request", [attachment]);

            var shareRequests = vestedShareTransferRepository.Get(v => request.Dto.VestedSharedRequestIds.Contains(v.Id))
                .Select(n => new VestedShareTransferModel
                {
                    Status = n.Status,
                    ApprovalDate = n.ApprovalDate,
                    HolderEmailAddress = n.HolderEmailAddress,
                    HolderName = n.HolderName,
                    ProcessedDate = n.ProcessedDate,
                    ReferenceNumber = n.ReferenceNumber,
                    TransferDate = n.TransferDate,
                    TransferValue = n.TransferValue
                }).ToList();

            await ProcessRequestAsync(approvedRequests, cancellationToken);

            //foreach (var shareRequest in shareRequests)
            //{
            //    var emailModel = new EmailModel
            //    {
            //        EmailAddress = shareRequest.HolderEmailAddress,
            //        Message = $"Dear {shareRequest.HolderName}\n\nYour vested share request of {shareRequest.TransferValue:N2} has been sent to your broker.",
            //        Subject = "Vested Share Request Update"
            //    };

            //    await offerEmailChannel.QueueItemAsync(emailModel);
            //}

            return stream;
        }

        async Task ProcessRequestAsync(List<SendToBrokerModel> vestedSharedRequests, CancellationToken cancellationToken)
        {

            //update offer value

            //update vestedsharerequest status to Processed
            foreach (var item in vestedSharedRequests)
            {
                logger.LogInformation("Processing vested share request with Reference {@Reference} and email {@email}", item.ReferenceNumber, item.HolderEmail);
                var vestedShare = vestedShareTransferRepository.UpdateVestedSharedRequestToProcess(item.ReferenceNumber, item.HolderEmail);
                logger.LogInformation("Processed vestedshare for email {@email} with {@Id}", item.HolderEmail, vestedShare?.Id);
                //convert into shares
                if (vestedShare is not null)
                {
                    var shareholder = await shareholderRepository.Get(s => s.ShareholderEmailAddress == item.HolderEmail)
                        .FirstOrDefaultAsync();
                    if(shareholder is null)
                    {
                        await shareholderRepository.AddAsync(new Domain.Models.Shareholder
                        {
                            BrokerId = vestedShare.BrokerId,
                            ChnNumber = vestedShare.ChnNumber,
                            CompanyId = userIdentityService.CompanyId,
                            CscsNumber = vestedShare.CscsNumber,
                            Holding = item.TransferValue,
                            PercentageHolding = 0.0M,
                            ShareholderEmailAddress = item.HolderEmail,
                            ShareholderName = vestedShare.HolderName
                        });

                    }
                    else
                    {
                        shareholder.Holding += item.TransferValue;
                    }

                    //save into transaction history table
                    await transactionHistoryRepository.AddAsync(new Domain.Models.TransactionHistory
                    {
                        Amount = vestedShare.TransferValue,
                        CompanyId = userIdentityService.CompanyId,
                        Description = "Shares granted",
                        Source = "Shares",
                        TransactionDate = DateTime.Now, 
                        UserEmailAddress = vestedShare.HolderEmailAddress
                    });
                }
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            //email 
            var emailModels = vestedSharedRequests.Select(e => new EmailModel
            {
                EmailAddress = e.HolderEmail,
                Message = $"Dear {e.HolderName},\n\n Your vested share request of {e.TransferValue:N2} has been sent to your broker and converted into shares. Congratulations",
                Subject = "Employee EquityPlan Status"
            }).ToList();

            foreach (var email in emailModels)
            {
                await offerEmailChannel.QueueItemAsync(email);
            }
        }

    }
}
