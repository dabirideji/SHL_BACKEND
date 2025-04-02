using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using SHL.Application.DTO.Company;
using SHL.Application.DTO.Staff;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record CreateEmployeeCommand(CreateEmployeeDto Dto) : IRequest;
    class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly IValidator<CreateEmployeeDto> validator;
        private readonly IApplicationUserRepository ApplicationUserRepository;
        private readonly IConfiguration configuration;

        public CreateEmployeeCommandHandler(IValidator<CreateEmployeeDto> validator,
            IApplicationUserRepository ApplicationUserRepository,
            IConfiguration configuration)
        {
            this.validator = validator;
            this.ApplicationUserRepository = ApplicationUserRepository;
            this.configuration = configuration;
        }
        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var staffOnboardingDto = new StaffOnboardingDto
            {
                Password = "",
                AccountNumber = "",
                BankName = "",
                ConfirmPassword = "",
                Country = "",
                EmailAddress = request.Dto.EmailAddress,
                EmployeeId = request.Dto.StaffCode,
                FirstName = request.Dto.FirstName,
                LastName = request.Dto.LastName,
                PhoneNumber = request.Dto.PhoneNumber,
                SwitfCode = "",
                Department = request.Dto.Department,
                Designation = request.Dto.Designation
            };
            var onboardingResult = await ApplicationUserRepository.OnboardStaffAsync(staffOnboardingDto, cancellationToken);
            if (!onboardingResult.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in onboardingResult.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.EmailAddress), error.Description));
                }

                throw new FluentValidation.ValidationException(errors);
            }

            //send onboarding email
            var token = await ApplicationUserRepository.GeneratePasswordResetTokenAsync(request.Dto.EmailAddress, cancellationToken);

            var baseUrl = configuration["FrontendBaseUrl"]!;

            await ApplicationUserRepository.SendStaffOnboardingLinkAsync(baseUrl, request.Dto.EmailAddress, token.Item2, cancellationToken);
        }
    }
}
