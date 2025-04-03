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
        private readonly IApplicationUserRepository ApplicationUserRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public VerifyEmailCommandHandler(IValidator<VerifyEmailDto> validator,
            IApplicationUserRepository ApplicationUserRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.validator = validator;
            this.ApplicationUserRepository = ApplicationUserRepository;
            this.userManager = userManager;
        }
        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var result = await ApplicationUserRepository.ValidateOtpAsync(request.Dto.EmailAddress, "verify_email", request.Dto.Otp);
            if (!result.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.Otp), error.Description));
                }

                throw new ValidationException(errors);
            }

            var confirmationResult = await ApplicationUserRepository.ConfirmEmailAsync(request.Dto.EmailAddress);
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
