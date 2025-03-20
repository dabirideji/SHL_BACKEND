using FluentValidation;
using SHL.Application.DTO.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Staff
{
    public class EditProfileDtoValidator : AbstractValidator<EditProfileDto>
    {
        public EditProfileDtoValidator()
        {
            RuleFor(c => c.PhoneNumber)
                .MaximumLength(11)
                .NotEmpty();

            RuleFor(c => c.ChnNumber)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.AccountNumber)
              .MaximumLength(10);
        }
    }
}
