using FluentValidation;
using MediatR;
using SHL.Application.DTO.CompanyDepartment;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.CompanyDepartment.Commands
{
    public record CreateDepartmentCommand(CreateDepartmentDto Dto) :IRequest;
    class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand>
    {
        private readonly IValidator<CreateDepartmentDto> validator;
        private readonly ICompanyDepartmentRepository companyDepartmentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserIdentityService userIdentityService;

        public CreateDepartmentCommandHandler(IValidator<CreateDepartmentDto> validator,
            ICompanyDepartmentRepository companyDepartmentRepository,
            IUnitOfWork unitOfWork,
            IUserIdentityService userIdentityService)
        {
            this.validator = validator;
            this.companyDepartmentRepository = companyDepartmentRepository;
            this.unitOfWork = unitOfWork;
            this.userIdentityService = userIdentityService;
        }
        public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            await companyDepartmentRepository.AddAsync(new Domain.Models.CompanyDepartment
            {
                CompanyId = userIdentityService.CompanyId,
                Department = request.Dto.Department,
                NormalizedDepartment = request.Dto.Department.ToUpperInvariant()
            });

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
