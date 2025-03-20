using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Company;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Company
{
    public class VerifyEmailDtoValidator : AbstractValidator<VerifyEmailDto>
    {
        public VerifyEmailDtoValidator(UserManager<CompanyUser> userManager)
        {
            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.Otp)
                .Length(6);

            RuleFor(c => c)
               .CustomAsync(async (model, context, ct) =>
               {

                   var user = await userManager.FindByNameAsync(model.EmailAddress);

                   if (user is null)
                   {
                       context.AddFailure(nameof(model.EmailAddress), "Email not found");
                   }
               });
        }
    }
}
