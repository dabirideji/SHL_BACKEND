using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Company;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record ToggleAdminCommand(ToggleAdminDto Dto) :IRequest;
    class ToggleAdminCommandHandler : IRequestHandler<ToggleAdminCommand>
    {
        private readonly IValidator<ToggleAdminDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;

        public ToggleAdminCommandHandler(IValidator<ToggleAdminDto> validator,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(ToggleAdminCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await companyUserRepository.ToggleAdminAsync(request.Dto.EmailAddress, request.Dto.IsAdmin, cancellationToken);
            if (!result.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.EmailAddress), error.Description));
                }

                throw new FluentValidation.ValidationException(errors);
            }
        }
    }
}
