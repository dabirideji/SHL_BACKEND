using FluentValidation;
using SHL.Application.DTO.Company.Request;

namespace SHL.Application.Validators
{
    public class StaffLoginDtoValidator : AbstractValidator<StaffLoginDto>
    {
        public StaffLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}