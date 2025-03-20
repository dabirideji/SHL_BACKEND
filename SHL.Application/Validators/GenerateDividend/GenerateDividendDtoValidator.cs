using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.GenerateDividend;
using SHL.Application.Repositories;

namespace SHL.Application.Validators.GenerateDividend
{
    public class GenerateDividendDtoValidator : AbstractValidator<GenerateDividendDto>
    {
        public GenerateDividendDtoValidator(IEquityPlanRepository equityPlanRepository,
            IGenerateDividendRepository generateDividendRepository)
        {
            RuleFor(c => c.EquityId)
                .NotEmpty();

            RuleFor(c => c.DividendPerShare)
                .GreaterThan(0);

            RuleFor(c => c.TaxInPercentage)
                .GreaterThan(0);

            RuleFor(c => c)
                .CustomAsync(async (model, context,ct) =>
                {
                    var equityPlan =await equityPlanRepository.Get(u => u.Id == model.EquityId)
                    .Select(c => new { c.Id, c.PlanName }).FirstOrDefaultAsync();

                    if (equityPlan is null)
                    {
                        context.AddFailure(nameof(model.EquityId), "Invalid equity");
                        return;
                    }
                    var hasDividend = await generateDividendRepository.Get(u => u.EquityId == model.EquityId)
                    .FirstOrDefaultAsync();

                    if(hasDividend is not null)
                    {
                        context.AddFailure(nameof(model.EquityId), "Equity already has dividend");
                        return;
                    }
                });
        }
    }
}
