using FluentValidation;
using SHL.Application.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Company
{
   public class CreateEmployeeDtoValidator:AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(c => c.StaffCode)
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

          
        }
    }
}
