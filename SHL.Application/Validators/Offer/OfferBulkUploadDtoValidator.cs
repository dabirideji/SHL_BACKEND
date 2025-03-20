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
   public class OfferBulkUploadDtoValidator:AbstractValidator<OfferBulkUploadDto>
    {
        public OfferBulkUploadDtoValidator(IEquityPlanRepository equityPlanRepository,
            IUserIdentityService userIdentityService)
        {
            RuleFor(c => c.EquityPlanId)
                .NotEmpty();

            RuleFor(c => c.OfferFile)
                .NotEmpty();

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var equityPlan =  equityPlanRepository.Get(e => e.Id == model.EquityPlanId && e.CompanyId == userIdentityService.CompanyId)
                    .FirstOrDefault();

                    if (equityPlan is null)
                    {
                        context.AddFailure(nameof(model.EquityPlanId), "Equity Plan not found");
                        return;
                    }

                    if (equityPlan.EquityType == Domain.Enums.EquityType.Options && model.ExcercisePrice <= 0)
                    {
                        context.AddFailure(nameof(model.ExcercisePrice), $"Excercise Price is required for equity type {Domain.Enums.EquityType.Options.ToString()}");
                    }
                });
        }
    }
}
