using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.CompanyDepartment;
using SHL.Application.Repositories;

namespace SHL.Application.Validators.CompanyDepartment
{
   public class CreateDepartmentDtoValidator:AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator(ICompanyDepartmentRepository companyDepartmentRepository)
        {
            RuleFor(c => c.Department)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var department = await companyDepartmentRepository.Get(u => u.NormalizedDepartment == model.Department.ToUpperInvariant())
                    .FirstOrDefaultAsync();

                    if(department is not null)
                    {
                        context.AddFailure(nameof(model.Department), "Department name already exist");
                        return;
                    }
                });
        }
    }
}
