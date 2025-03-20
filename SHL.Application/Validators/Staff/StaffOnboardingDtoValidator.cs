using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Staff;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Staff
{
   public class StaffOnboardingDtoValidator:AbstractValidator<StaffOnboardingDto>
    {
        public StaffOnboardingDtoValidator(UserManager<CompanyUser> userManager,
            IPasswordValidator<CompanyUser> passwordValidator,
            IUserValidator<CompanyUser> userValidator)
        {
            RuleFor(c => c.EmployeeId)
                 .NotEmpty();

            RuleFor(c => c.Country)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
                .NotEmpty();

            RuleFor(c => c.FirstName)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(c => c.LastName)
               .MaximumLength(100)
               .NotEmpty();

            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty();

            RuleFor(c => c.ConfirmPassword)
                .Equal(c => c.Password)
                .WithMessage("Password and ConfirmPassword do not match")
                .NotEmpty();

            RuleFor(c => c.BankName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.AccountNumber)
               .MaximumLength(20)
               .NotEmpty();

            RuleFor(c => c.SwitfCode)
               .MaximumLength(50)
               .NotEmpty();

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

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var user = new CompanyUser
                    {
                        UserName = model.EmailAddress,
                        Email = model.EmailAddress
                    };
                    var validationResult = await userValidator.ValidateAsync(userManager, user);

                    if (!validationResult.Succeeded)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            context.AddFailure(nameof(model.EmailAddress), error.Description);
                        }
                    }
                });
        }
    }
}
