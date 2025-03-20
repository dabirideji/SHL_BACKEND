using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.CustomExceptions;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record ChangeStatusCommand(Guid OfferId, string Status) : IRequest;
    class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand>
    {
        private readonly IUserIdentityService userIdentityService;
        private readonly IOfferRepository offerRepository;
        private readonly ITransactionHistoryRepository transactionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferEmailChannel offerEmailChannel;
        private readonly IAppSettingRepository appSettingRepository;
        private readonly IVestedShareTransferRepository vestedShareTransferRepository;
        private readonly IStaffRepository staffRepository;
        private readonly ICompanyUserRepository companyUserRepository;

        public ChangeStatusCommandHandler(IUserIdentityService userIdentityService,
            IOfferRepository offerRepository,
            ITransactionHistoryRepository transactionHistoryRepository,
            IUnitOfWork unitOfWork,
            IOfferEmailChannel offerEmailChannel,
            IAppSettingRepository appSettingRepository,
            IVestedShareTransferRepository vestedShareTransferRepository,
            IStaffRepository staffRepository,
            ICompanyUserRepository companyUserRepository)
        {
            this.userIdentityService = userIdentityService;
            this.offerRepository = offerRepository;
            this.transactionHistoryRepository = transactionHistoryRepository;
            this.unitOfWork = unitOfWork;
            this.offerEmailChannel = offerEmailChannel;
            this.appSettingRepository = appSettingRepository;
            this.vestedShareTransferRepository = vestedShareTransferRepository;
            this.staffRepository = staffRepository;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await offerRepository.ChangeOfferStatusAsync(request.OfferId, request.Status, cancellationToken);

            if (result > 0 && string.Equals(request.Status, "vested", StringComparison.OrdinalIgnoreCase))
            {
                await transactionHistoryRepository.SaveOfferAsTransactionHistoryAsync(new List<Guid> { request.OfferId }, request.Status, userIdentityService.CompanyId, cancellationToken);

                //transfer vested share
                var appSettings = await appSettingRepository.Get()
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (!appSettings.CanEmployeeTransferShares)
                {
                    var offer = await offerRepository.Get(o => o.Id == request.OfferId)
                        .Include(e => e.EquityPlan)
                        .FirstOrDefaultAsync();

                    if (offer is not null && offer.EquityPlan!.EquityType == Domain.Enums.EquityType.Rsu)
                    {
                        var employee = await staffRepository.ProfileByEmailAddressAsync(offer.EquityHolderEmailAddress);

                        var transferDto = new DTO.Offer.VestedOfferTransferRequestDto
                        {
                            OfferId = offer.Id,
                            TransferValue = offer.OfferValue,
                            ChnNumber = employee != null ? employee.ChnNumber : "",
                            CscsNumber = employee != null ? employee.CscsNumber : ""
                        };
                        await vestedShareTransferRepository.TransferShares(offer, transferDto, userIdentityService.CompanyId);
                    }
                }

                await unitOfWork.SaveChangesAsync(cancellationToken);

                //send email
                var offerEmail = offerRepository.Get(o => o.Id == request.OfferId && o.Status == request.Status)
                    .Select(e => new EmailModel
                    {
                        EmailAddress = e.EquityHolderEmailAddress,
                        Message = $"Dear {e.OfferHolder},\n\n Your offer of {e.OfferValue} is now vested and also share transfer request is sent to HR, pending approval. \n Kindly ensure your CHN is updated for shares to be approved.",
                        Subject = $"Offer Update"
                    }).ToList();

                foreach (var email in offerEmail)
                {
                    await offerEmailChannel.QueueItemAsync(email);
                }
            }
            else
            {
                ApiException.ClientError("No vested offer found");
            }

        }
    }
}
