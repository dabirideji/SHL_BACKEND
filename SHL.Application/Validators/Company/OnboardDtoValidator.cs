using FluentValidation;
using Hangfire.Storage.SQLite;
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
   public class OnboardDtoValidator:AbstractValidator<OnboardDto>
    {
        public OnboardDtoValidator(UserManager<CompanyUser> userManager,
            IPasswordValidator<CompanyUser> passwordValidator,
            IUserValidator<CompanyUser> userValidator)
        {
            RuleFor(c => c.CompanyName)
                 .MaximumLength(100)
                 .NotEmpty();

            RuleFor(c => c.Country)
                .NotEmpty();

            RuleFor(c => c.Address)
               .NotEmpty();

            RuleFor(c => c.DomainName)
                .NotEmpty();
                //.Must(c => IsValidUri(c))
                //.WithMessage("Domain name is not valid, must begin with https");

            RuleFor(c => c.CompanySize)
                .NotEmpty();

            RuleFor(c => c.AnnualRevenue)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
                .NotEmpty();

            RuleFor(c => c.FirstName)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(c => c.LastName)
               .MaximumLength(100)
               .NotEmpty();

            RuleFor(c => c.CompanyEmail)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.Password)
                .NotEmpty();

            RuleFor(c => c.ConfirmPassword)
                .Equal(c => c.Password)
                .WithMessage("Password and ConfirmPassword do not match")
                .NotEmpty();

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var user = new CompanyUser
                    {
                        UserName = model.CompanyEmail,
                        Email = model.CompanyEmail
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
                        UserName = model.CompanyEmail,
                        Email = model.CompanyEmail
                    };

                    var validationResult = await userValidator.ValidateAsync(userManager, user);

                    if (!validationResult.Succeeded)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            context.AddFailure(nameof(model.CompanyEmail), error.Description);
                        }
                    }
                });
                       
        }

        bool IsValidUri(string? link)
        {
            var status = Uri.TryCreate(link, UriKind.Absolute, out Uri? uri);
            return status && uri?.Scheme == Uri.UriSchemeHttps;
        }
    }
}
