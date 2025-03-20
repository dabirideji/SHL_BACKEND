using FluentValidation;
using SHL.Application.DTO.Company;
using SHL.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Company
{
  public  class ChangeStaffStatusDtoValidator:AbstractValidator<ChangeStaffStatusDto>
    {
        public ChangeStaffStatusDtoValidator()
        {
            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();

            RuleFor(c => c.Status)
                .Must(c=>Enum.TryParse(typeof(StaffStatus),c,out object? _))
                .WithMessage("Invalid status");
        }
    }
}
