using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Dividend;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Domain.Enums;

namespace SHL.Application.Validators.Dividend
{
    public class DividendPayoutRequestDtoValidator : AbstractValidator<DividendPayoutRequestDto>
    {
        public DividendPayoutRequestDtoValidator(IDividendRepository dividendRepository,
            IUserIdentityService userIdentityService,
            IDividendPayoutRequestRepository dividendPayoutRequestRepository)
        {
            RuleFor(c => c.DividendId)
                .NotEmpty();

            RuleFor(c => c.Amount)
                .GreaterThan(0);

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    //check if there is an existing payment request
                    var hasPaymentRequest = await dividendPayoutRequestRepository.Get(u => u.EmployeeEmailAddress == userIdentityService.EmailAddress && u.Status == PayoutRequest.Pending.ToString())
                    .AnyAsync();

                    if (hasPaymentRequest)
                    {
                        context.AddFailure(nameof(model.Amount), "You have a pending payout request awaiting approval");
                        return;
                    }

                    var dividend = await dividendRepository.Get(u => u.Id == model.DividendId && u.EmployeeEmailAddress == userIdentityService.EmailAddress)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                    if (dividend is null)
                    {
                        context.AddFailure(nameof(model.DividendId), "Invalid dividend");
                        return;
                    }

                    if (model.Amount > dividend.UnClaimedAmount)
                    {
                        context.AddFailure(nameof(model.Amount), $"Requested amount cannot be more than unclaimed amount {dividend.UnClaimedAmount:N2}");
                    }
                });
        }
    }
}
