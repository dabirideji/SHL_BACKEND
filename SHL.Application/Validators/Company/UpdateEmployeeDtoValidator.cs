using FluentValidation;
using SHL.Application.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Company
{
   public class UpdateEmployeeDtoValidator:AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeDtoValidator()
        {
            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
