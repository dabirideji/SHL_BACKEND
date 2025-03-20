using FluentValidation;
using SHL.Application.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Company
{
   public class UpdateCompanyInfoDtoValidator:AbstractValidator<UpdateCompanyInfoDto>
    {
        public UpdateCompanyInfoDtoValidator()
        {
            RuleFor(c => c.CompanyName)
                .MaximumLength(150)
                .NotEmpty();

            RuleFor(c => c.CompanyEmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.TotalShares)
                .GreaterThan(0);

            RuleFor(c => c.SharePrice)
               .GreaterThan(0);
                     
        }
    }
}
