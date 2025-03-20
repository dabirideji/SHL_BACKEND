using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Company;
using SHL.Application.Repositories;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record VerifyEmailCommand(VerifyEmailDto Dto) :IRequest;
    class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
    {
        private readonly IValidator<VerifyEmailDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly UserManager<CompanyUser> userManager;

        public VerifyEmailCommandHandler(IValidator<VerifyEmailDto> validator,
            ICompanyUserRepository companyUserRepository,
            UserManager<CompanyUser> userManager)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
            this.userManager = userManager;
        }
        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await companyUserRepository.ValidateOtpAsync(request.Dto.EmailAddress, "verify_email", request.Dto.Otp);
            if (!result.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.Otp), error.Description));
                }

                throw new ValidationException(errors);
            }

            var confirmationResult = await companyUserRepository.ConfirmEmailAsync(request.Dto.EmailAddress);
            if (!confirmationResult.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in confirmationResult.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.EmailAddress), error.Description));
                }

                throw new ValidationException(errors);
            }
        }
    }
}
