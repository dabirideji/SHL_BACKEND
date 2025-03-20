using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Account;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Account.Commands
{
    public record EmployeeInfoUpdateCommand(EmployeeInfoUpdateDto Dto) :IRequest;
    class EmployeeInfoUpdateCommandHandler : IRequestHandler<EmployeeInfoUpdateCommand>
    {
        private readonly IValidator<EmployeeInfoUpdateDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;

        public EmployeeInfoUpdateCommandHandler(IValidator<EmployeeInfoUpdateDto> validator,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(EmployeeInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await companyUserRepository.UpdateEmployeeProfile(request.Dto, cancellationToken);
            if (!result.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.EmailAddress), error.Description));
                }
                throw new ValidationException(errors);
            }
        }
    }
}
