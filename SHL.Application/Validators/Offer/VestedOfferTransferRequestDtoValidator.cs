using Azure.Core;
using FluentValidation;
using SHL.Application.DTO.Offer;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Offer
{
    public class VestedOfferTransferRequestDtoValidator : AbstractValidator<VestedOfferTransferRequestDto>
    {
        public VestedOfferTransferRequestDtoValidator(IOfferRepository offerRepository,
            IUserIdentityService userIdentityService,
            IBrokerRepository brokerRepository)
        {
            RuleFor(c => c.OfferId)
                .NotEmpty();

            RuleFor(c => c.BrokerId)
                .NotEmpty();

            RuleFor(c => c.ChnNumber)
                .NotEmpty();

            RuleFor(c => c.TransferValue)
                .GreaterThan(0);

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var offer = offerRepository.Get(o => o.Id == model.OfferId  && o.EquityHolderEmailAddress == userIdentityService.EmailAddress)
                                 .FirstOrDefault();

                    //&& o.Status == Domain.Enums.Offer.Vested.ToString()
                    if (offer is null)
                    {
                        context.AddFailure(nameof(model.OfferId), "Offer not found");
                        return;
                    }

                    if(offer.Status != Domain.Enums.Offer.Vested.ToString())
                    {
                        context.AddFailure(nameof(model.OfferId), "Offer can only be transferred when it's vested");
                        return;
                    }

                    if (model.TransferValue > offer.BalanceOfferValue)
                    {
                        context.AddFailure(nameof(model.TransferValue), $"Transfer value cannot be more than {offer.BalanceOfferValue}");
                    }

                    var broker = await brokerRepository.GetByIdAsync(model.BrokerId);
                    if (broker is null)
                    {
                        context.AddFailure(nameof(model.BrokerId), "Invalid broker");
                    }
                });
        }
    }
}
