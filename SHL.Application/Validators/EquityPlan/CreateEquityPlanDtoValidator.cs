using FluentValidation;
using SHL.Application.DTO.EquityPlan;
using SHL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.EquityPlan
{
    public class CreateEquityPlanDtoValidator : AbstractValidator<CreateEquityPlanDto>
    {
        public CreateEquityPlanDtoValidator()
        {
            var equityPlans = Enum.GetNames(typeof(EquityType));
            RuleFor(c => c.PlanName)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(c => c.TotalEquity)
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.EquityType)
                .Must(c=>equityPlans.Contains(c))
                .WithMessage("{PropertyName} must either by Rsu or Options");

            RuleFor(c => c)
                .Custom((model, context) =>
                {
                    if(!string.IsNullOrEmpty(model.OfferLetterName) && string.IsNullOrEmpty(model.OfferLetterContent))
                    {
                        context.AddFailure(nameof(model.OfferLetterContent), "please provide offer letter content when offer letter is not empty");
                    }

                    if (!string.IsNullOrEmpty(model.PlanRuleName) && string.IsNullOrEmpty(model.PlanRuleContentUrl))
                    {
                        context.AddFailure(nameof(model.OfferLetterContent), "please upload plan rule content when plan rule is not empty");
                    }

                    if (!string.IsNullOrEmpty(model.PlanRuleName) && !IsValidUri(model.PlanRuleContentUrl))
                    {
                        context.AddFailure(nameof(model.PlanRuleContentUrl), "please upload plan rule content when plan rule is not empty");
                        return;
                    }
                });
        }

        bool IsValidUri(string? link)
        {
            var status = Uri.TryCreate(link, UriKind.Absolute, out Uri? uri);
            return status && uri?.Scheme == Uri.UriSchemeHttps;
        }
    }
}
