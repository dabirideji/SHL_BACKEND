using FluentValidation;
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
    public record ResetPasswordCommand(ResetPasswordDto Dto) : IRequest;
    class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly IValidator<ResetPasswordDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;

        public ResetPasswordCommandHandler(IValidator<ResetPasswordDto> validator,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await companyUserRepository.ResetPasswordAsync(request.Dto.EmailAddress, request.Dto.Token, request.Dto.Password, cancellationToken);
        }
    }
}
