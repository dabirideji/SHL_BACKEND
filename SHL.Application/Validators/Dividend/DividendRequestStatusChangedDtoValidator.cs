using FluentValidation;
using SHL.Application.DTO.Dividend;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Dividend
{
   public class DividendRequestStatusChangedDtoValidator:AbstractValidator<DividendRequestStatusChangedDto>
    {
        public DividendRequestStatusChangedDtoValidator(IDividendPayoutRequestRepository dividendPayoutRequestRepository)
        {
            RuleFor(c => c.PayoutRequestIds)
                .NotEmpty();

            RuleFor(c => c.Status)
                .Must(c => Enum.TryParse(typeof(Domain.Enums.PayoutRequest), c, out object? _));

            RuleFor(c => c)
               .Custom((model, context) =>
               {
                   if (string.IsNullOrEmpty(model.DeclineComment) && string.Equals(model.Status, Domain.Enums.DividedStatus.Declined.ToString(), StringComparison.OrdinalIgnoreCase))
                   {
                       context.AddFailure(nameof(model.DeclineComment), "please provide a comment when request is declined");
                       return;
                   }
               });
        }
    }
}
