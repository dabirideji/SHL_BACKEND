using Azure.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Offer;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Offer
{
    public class CreateOfferDtoValidator : AbstractValidator<CreateOfferDto>
    {
        public CreateOfferDtoValidator(IEquityPlanRepository equityPlanRepository)
        {
            RuleFor(c => c.OfferValue)
                .GreaterThan(0);

            RuleFor(c => c.EmailAddresses)
                .NotEmpty();

            RuleFor(c => c.VestStartDate)
                .NotEmpty();

            RuleFor(c => c.VestEndDate)
                .NotEmpty();

            RuleFor(c => c)
                .Must(c => c.VestEndDate > c.VestStartDate)
                .WithMessage("enddate must be greater than start date");

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var equityPlan = await equityPlanRepository.Get(u => u.Id == model.EquityPlanId)
                    .FirstOrDefaultAsync();

                    if (equityPlan is null)
                    {
                        context.AddFailure(nameof(model.EquityPlanId), "Equity plan not found");
                        return;
                    }

                    if (model.OfferValue > equityPlan.UnAllocated)
                    {
                        context.AddFailure(nameof(model.OfferValue), $"Offer value cannot be more than unallocated equity of {equityPlan.UnAllocated:N2}");

                    }
                    if (equityPlan.EquityType == Domain.Enums.EquityType.Options && model.ExcercisePrice <= 0)
                    {
                        context.AddFailure(nameof(model.ExcercisePrice), $"Excercise Price is required for equity type {Domain.Enums.EquityType.Options.ToString()}");
                    }
                });
        }
    }
}
