using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Account;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Account
{
   public class EmployeeInfoUpdateDtoValidator:AbstractValidator<EmployeeInfoUpdateDto>
    {
        public EmployeeInfoUpdateDtoValidator(UserManager<CompanyUser> userManager,
            IPasswordValidator<CompanyUser> passwordValidator)
        {
            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.Token)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
              .MaximumLength(50);

            RuleFor(c => c.Password)
              .NotEmpty();

            RuleFor(c => c.ConfirmPassword)
              .NotEmpty()
              .Equal(c => c.Password)
              .WithMessage("Confirm password and Password does not match");

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var user = new CompanyUser
                    {
                        UserName = model.EmailAddress,
                        Email = model.EmailAddress
                    };

                    var passwordResult = await passwordValidator.ValidateAsync(userManager, user, model.Password);

                    if (!passwordResult.Succeeded)
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            context.AddFailure(nameof(model.Password), error.Description);
                        }
                    }
                });
        }
    }
}
