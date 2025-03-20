using FluentValidation;
using SHL.Application.DTO.VestedShareTransfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.VestedShareTransfer
{
    public class ChangeStatusDtoValidator : AbstractValidator<ChangeStatusDto>
    {
        public ChangeStatusDtoValidator()
        {
            RuleFor(c => c.Ids)
                .NotEmpty();

            RuleFor(c => c.Status)
                .Must(c => Enum.TryParse(c, out Domain.Enums.VestesShareTransfer _))
                .WithMessage("Invalid status");

            RuleFor(c => c)
                .Custom((model, context) =>
                {
                    if(string.IsNullOrEmpty(model.DeclineComment) && string.Equals(model.Status, Domain.Enums.VestesShareTransfer.Declined.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        context.AddFailure(nameof(model.DeclineComment), "please provide a comment when request is declined");
                        return;
                    }
                });
        }
    }
}
