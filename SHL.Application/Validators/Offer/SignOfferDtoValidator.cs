using FluentValidation;
using SHL.Application.DTO.Offer;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Offer
{
    public class SignOfferDtoValidator : AbstractValidator<SignOfferDto>
    {
        public SignOfferDtoValidator(IOfferRepository offerRepository,
            IUserIdentityService userIdentityService)
        {
            RuleFor(c => c.OfferId)
                .NotEmpty();

            RuleFor(c => c.Signature)
               .NotEmpty();

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var offer = offerRepository.Get(x => x.Id == model.OfferId && x.EquityHolderEmailAddress == userIdentityService.EmailAddress)
                    .FirstOrDefault();

                    if (offer is null)
                    {
                        context.AddFailure(nameof(model.OfferId), "Offer not found");
                    }
                });
        }
    }
}
