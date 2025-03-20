using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Account;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Account.Commands
{
    public record ChangePasswordCommand(ChangePasswordDto Dto) :IRequest;
    class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IValidator<ChangePasswordDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly IUserIdentityService userIdentityService;

        public ChangePasswordCommandHandler(IValidator<ChangePasswordDto> validator,
            ICompanyUserRepository companyUserRepository,
            IUserIdentityService userIdentityService)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
            this.userIdentityService = userIdentityService;
        }
        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await companyUserRepository.ChangePasswordAsync(userIdentityService.EmailAddress, request.Dto.CurrentPassword, request.Dto.NewPassword, cancellationToken);
            if (!result.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.NewPassword), error.Description));
                }

                throw new ValidationException(errors);
            }
        }
    }
}
