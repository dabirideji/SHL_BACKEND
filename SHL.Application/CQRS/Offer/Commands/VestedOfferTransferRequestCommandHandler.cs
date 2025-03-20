using FluentValidation;
using MediatR;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record VestedOfferTransferRequestCommand(VestedOfferTransferRequestDto Dto) : IRequest;
    class VestedOfferTransferRequestCommandHandler : IRequestHandler<VestedOfferTransferRequestCommand>
    {
        private readonly IValidator<VestedOfferTransferRequestDto> validator;
        private readonly IOfferRepository offerRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IVestedShareTransferRepository vestedShareTransferRepository;
        private readonly IOfferEmailChannel offerEmailChannel;

        public VestedOfferTransferRequestCommandHandler(IValidator<VestedOfferTransferRequestDto> validator,
            IOfferRepository offerRepository,
            IUserIdentityService userIdentityService,
            IUnitOfWork unitOfWork,
            IVestedShareTransferRepository vestedShareTransferRepository,
            IOfferEmailChannel offerEmailChannel)
        {
            this.validator = validator;
            this.offerRepository = offerRepository;
            this.userIdentityService = userIdentityService;
            this.unitOfWork = unitOfWork;
            this.vestedShareTransferRepository = vestedShareTransferRepository;
            this.offerEmailChannel = offerEmailChannel;
        }
        public async Task Handle(VestedOfferTransferRequestCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var offer = offerRepository.Get(o => o.Id == request.Dto.OfferId && o.Status == Domain.Enums.Offer.Vested.ToString() && o.EquityHolderEmailAddress == userIdentityService.EmailAddress)
                 .FirstOrDefault();

            // save in VestedTransferRequest table
            await vestedShareTransferRepository.AddAsync(new Domain.Models.VestedShareTransfer
            {
                BrokerId = request.Dto.BrokerId,
                ChnNumber = request.Dto.ChnNumber,
                CompanyId = userIdentityService.CompanyId,
                CscsNumber = request.Dto.CscsNumber ?? "",
                HolderEmailAddress = offer!.EquityHolderEmailAddress,
                HolderName = offer!.OfferHolder,
                OfferId = request.Dto.OfferId,
                ReferenceNumber = Guid.NewGuid().ToString(),
                Status = Domain.Enums.VestesShareTransfer.PendingApproval.ToString(),
                TransferValue = request.Dto.TransferValue
            });

            offer.BalanceOfferValue = offer.OfferValue - request.Dto.TransferValue;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var offerEmail = new EmailModel
            {
                EmailAddress = offer.EquityHolderEmailAddress,
                Message = $"Dear {offer.OfferHolder},\n\n Your vested share transfer is pending approval with HR. You will be notified as soon as approval is made and shares sent to broker.",
                Subject = "Veste share transfer request"
            };

            await offerEmailChannel.QueueItemAsync(offerEmail);

        }
    }
}
