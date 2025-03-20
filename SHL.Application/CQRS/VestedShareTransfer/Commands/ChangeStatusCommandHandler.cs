using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.VestedShareTransfer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.VestedShareTransfer.Commands
{
    public record ChangeVestedShareTransferStatusCommand(ChangeStatusDto Dto) : IRequest;
    class ChangeStatusCommandHandler : IRequestHandler<ChangeVestedShareTransferStatusCommand>
    {
        private readonly IValidator<ChangeStatusDto> validator;
        private readonly IVestedShareTransferRepository vestedShareTransferRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IOfferRepository offerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferEmailChannel offerEmailChannel;
        private readonly IStaffRepository staffRepository;

        public ChangeStatusCommandHandler(IValidator<ChangeStatusDto> validator,
            IVestedShareTransferRepository vestedShareTransferRepository,
            IUserIdentityService userIdentityService,
            IOfferRepository offerRepository,
            IUnitOfWork unitOfWork,
            IOfferEmailChannel offerEmailChannel,
            IStaffRepository staffRepository)
        {
            this.validator = validator;
            this.vestedShareTransferRepository = vestedShareTransferRepository;
            this.userIdentityService = userIdentityService;
            this.offerRepository = offerRepository;
            this.unitOfWork = unitOfWork;
            this.offerEmailChannel = offerEmailChannel;
            this.staffRepository = staffRepository;
        }
        public async Task Handle(ChangeVestedShareTransferStatusCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            if (string.Equals(request.Dto.Status, Domain.Enums.VestesShareTransfer.Declined.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var vestedShareTransfers = await vestedShareTransferRepository.Get(u => request.Dto.Ids.Contains(u.Id))
                    .Include(o => o.Offer)
                    .ToListAsync();
                foreach (var vs in vestedShareTransfers)
                {
                    vs.Offer!.BalanceOfferValue = vs.Offer.BalanceOfferValue + vs.TransferValue;
                }

                await unitOfWork.SaveChangesAsync(cancellationToken);
                return;
            }

            var vestedShares = await vestedShareTransferRepository.Get(v => request.Dto.Ids.Contains(v.Id))
                .ToListAsync();

            foreach (var vestedShare in vestedShares)
            {
                if (string.IsNullOrEmpty(vestedShare.ChnNumber))
                {
                    //get employee profile to update CHN 
                    var employeeProfile = await staffRepository.ProfileByEmailAddressAsync(vestedShare.HolderEmailAddress);
                    if (employeeProfile is not null && !string.IsNullOrEmpty(employeeProfile.ChnNumber))
                    {
                        vestedShare.ChnNumber = employeeProfile.ChnNumber;
                        vestedShare.CscsNumber = employeeProfile.CscsNumber;
                        vestedShare.Status = request.Dto.Status;
                        vestedShare.ApprovalDate = DateTime.Now;
                    }
                }
                else
                {
                    vestedShare.Status = request.Dto.Status;
                    vestedShare.ApprovalDate = DateTime.Now;
                }

            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            //var vestedShareRequest = await vestedShareTransferRepository.ChangeRequestStatusAsync(request.Dto.Ids, userIdentityService.CompanyId, request.Dto.Status, request.Dto.DeclineComment, cancellationToken);

            //email status
            //var shareRequests = vestedShares.Where(v => !string.IsNullOrEmpty(v.ChnNumber))
            //    .Select(n => new VestedShareTransferModel
            //    {
            //        Status = n.Status,
            //        ApprovalDate = n.ApprovalDate,
            //        HolderEmailAddress = n.HolderEmailAddress,
            //        HolderName = n.HolderName,
            //        ProcessedDate = n.ProcessedDate,
            //        ReferenceNumber = n.ReferenceNumber,
            //        TransferDate = n.TransferDate,
            //        TransferValue = n.TransferValue
            //    }).ToList();

            //foreach (var shareRequest in shareRequests)
            //{
            //    var emailModel = new EmailModel
            //    {
            //        EmailAddress = shareRequest.HolderEmailAddress,
            //        Message = $"Dear {shareRequest.HolderName}\n\nYour vested share request of {shareRequest.TransferValue:N2} has been {shareRequest.Status}",
            //        Subject = "Vested Share Request Update"
            //    };

            //    await offerEmailChannel.QueueItemAsync(emailModel);
            //}

            var processedShareRequests = vestedShares.Where(v => !string.IsNullOrEmpty(v.ChnNumber))
               .Select(n => new EmailModel
               {
                   EmailAddress = n.HolderEmailAddress,
                   Message = $"Dear {n.HolderName}\n\nYour vested share request of {n.TransferValue:N2} has been {n.Status}",
                   Subject = "Vested Share Request Update"
               }).ToList();

            foreach (var emailModel in processedShareRequests)
            {
                await offerEmailChannel.QueueItemAsync(emailModel);
            }


            var unprocessedShareRequests = vestedShares.Where(v => string.IsNullOrEmpty(v.ChnNumber))
              .Select(n => new EmailModel
              {
                  EmailAddress = n.HolderEmailAddress,
                  Message = $"Dear {n.HolderName}\n\nYour vested share request of {n.TransferValue:N2} is not processed due to missing CHN, kindly update your CHN or contact HR.",
                  Subject = "Vested Share Request Update"
              }).ToList();

            foreach (var emailModel in unprocessedShareRequests)
            {
                await offerEmailChannel.QueueItemAsync(emailModel);
            }
        }
    }
}
