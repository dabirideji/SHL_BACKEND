using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Account;
using SHL.Application.IServices;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Account
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator(UserManager<CompanyUser> userManager,
            IPasswordValidator<CompanyUser> passwordValidator,
            IUserIdentityService userIdentityService)
        {
            RuleFor(c => c.CurrentPassword)
                .NotEmpty();

            RuleFor(c => c.NewPassword)
                .NotEmpty();

            RuleFor(c => c.ConfirmNewPassword)
              .NotEmpty()
              .Equal(c => c.NewPassword)
              .WithMessage("Confirm password and Password does not match");

            RuleFor(c => c)
               .CustomAsync(async (model, context, ct) =>
               {
                   var user = new CompanyUser
                   {
                       UserName = userIdentityService.EmailAddress,
                       Email = userIdentityService.EmailAddress
                   };

                   var passwordResult = await passwordValidator.ValidateAsync(userManager, user, model.NewPassword);

                   if (!passwordResult.Succeeded)
                   {
                       foreach (var error in passwordResult.Errors)
                       {
                           context.AddFailure(nameof(model.NewPassword), error.Description);
                       }
                   }
               });
        }
    }
}
