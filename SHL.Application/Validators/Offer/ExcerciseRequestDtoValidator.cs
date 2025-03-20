using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Offer;
using SHL.Application.Repositories;

namespace SHL.Application.Validators.Offer
{
    public class ExcerciseRequestDtoValidator : AbstractValidator<ExcerciseRequestDto>
    {
        public ExcerciseRequestDtoValidator(IOfferRepository offerRepository)
        {
            RuleFor(c => c.OfferId)
                .NotEmpty();

            RuleFor(c => c.Quantity)
                .GreaterThan(0);

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var offer = await offerRepository.Get(u => u.Id == model.OfferId)
                    .Include(c => c.EquityPlan)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                    if (offer is null)
                    {
                        context.AddFailure(nameof(model.OfferId), "Offer not found");
                        return;
                    }

                    if (offer.EquityPlan!.EquityType != Domain.Enums.EquityType.Options)
                    {
                        context.AddFailure(nameof(model.OfferId), "Offer must be of Options Equity Type");
                        return;
                    }

                });
        }
    }
}
