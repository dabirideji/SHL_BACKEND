using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Company;
using SHL.Application.Repositories;
using SHL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record OnboardCommand(OnboardDto Dto) : IRequest;
    class OnboardCommandHandler : IRequestHandler<OnboardCommand>
    {
        private readonly IValidator<OnboardDto> validator;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly IMailService mailService;

        public OnboardCommandHandler(IValidator<OnboardDto> validator,
            ICompanyUserRepository companyUserRepository,
            IMailService mailService)
        {
            this.validator = validator;
            this.companyUserRepository = companyUserRepository;
            this.mailService = mailService;
        }
        public async Task Handle(OnboardCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var onboardingResult = await companyUserRepository.OnboardAsync(request.Dto);
            if (!onboardingResult.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in onboardingResult.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.CompanyEmail), error.Description));
                }

                throw new ValidationException(errors);
            }

            var otp = await companyUserRepository.GenerateOtpAsync(request.Dto.CompanyEmail, "verify_email");
            _ = await mailService.SendMail(request.Dto.CompanyEmail, $"Your email verification OTP is {otp.Item2}. It expires in 5 min", "Verify your email");
        }
    }
}
