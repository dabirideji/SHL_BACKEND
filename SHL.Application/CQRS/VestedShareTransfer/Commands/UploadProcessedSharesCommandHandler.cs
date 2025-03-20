using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SHL.Application.DTO.VestedShareTransfer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.VestedShareTransfer.Commands
{
    public record UploadProcessedSharesCommand(UploadProcessedSharesDto Dto) : IRequest;
    class UploadProcessedSharesCommandHandler : IRequestHandler<UploadProcessedSharesCommand>
    {
        private readonly IValidator<UploadProcessedSharesDto> validator;
        private readonly IExcelProcessor excelProcessor;
        private readonly IVestedShareTransferRepository vestedShareTransferRepository;
        private readonly IShareholderRepository shareholderRepository;
        private readonly ITransactionHistoryRepository transactionHistoryRepository;
        private readonly IOfferEmailChannel offerEmailChannel;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserIdentityService userIdentityService;

        public UploadProcessedSharesCommandHandler(IValidator<UploadProcessedSharesDto> validator,
            IExcelProcessor excelProcessor,
            IVestedShareTransferRepository vestedShareTransferRepository,
            IShareholderRepository shareholderRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IOfferEmailChannel offerEmailChannel,
            IUnitOfWork unitOfWork,
            IUserIdentityService userIdentityService)
        {
            this.validator = validator;
            this.excelProcessor = excelProcessor;
            this.vestedShareTransferRepository = vestedShareTransferRepository;
            this.shareholderRepository = shareholderRepository;
            this.transactionHistoryRepository = transactionHistoryRepository;
            this.offerEmailChannel = offerEmailChannel;
            this.unitOfWork = unitOfWork;
            this.userIdentityService = userIdentityService;
        }
        public async Task Handle(UploadProcessedSharesCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var vestedSharedRequests = excelProcessor.ReadVestedShareRequestFromExcel(request.Dto.File.OpenReadStream());

            //update offer value

            //update vestedsharerequest status to Processed
            foreach (var item in vestedSharedRequests)
            {
                var vestedShare = vestedShareTransferRepository.UpdateVestedSharedRequestToProcess(item.ReferenceNumber, item.EmailAddress);
                //convert into shares
                if (vestedShare is not null)
                {
                    await shareholderRepository.AddAsync(new Domain.Models.Shareholder
                    {
                        BrokerId = vestedShare.BrokerId,
                        ChnNumber = vestedShare.ChnNumber,
                        CompanyId = userIdentityService.CompanyId,
                        CscsNumber = vestedShare.CscsNumber,
                        Holding = item.TransferRequestValue,
                        PercentageHolding = 0.0M,
                        ShareholderEmailAddress = item.EmailAddress,
                        ShareholderName = vestedShare.HolderName
                    });

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
                EmailAddress = e.EmailAddress,
                Message = $"Dear {e.FullName},\n\n Your vested share request of {e.TransferRequestValue:N2} has been processed and converted into shares. Congratulations",
                Subject = "Employee EquityPlan Status"
            }).ToList();

            foreach (var email in emailModels)
            {
                await offerEmailChannel.QueueItemAsync(email);
            }
        }
    }
}
