using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Staff;
using SHL.Application.Repositories;
using SHL.Application.Services;

namespace SHL.Application.CQRS.Staff.Commands
{
    public record StaffOnboardingCommand(StaffOnboardingDto Dto) :IRequest;
    class StaffOnboardingCommandHandler : IRequestHandler<StaffOnboardingCommand>
    {
        private readonly IValidator<StaffOnboardingDto> validator;
        private readonly IMailService mailService;
        private readonly ICompanyUserRepository companyUserRepository;

        public StaffOnboardingCommandHandler(IValidator<StaffOnboardingDto> validator,
            IMailService mailService,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.mailService = mailService;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(StaffOnboardingCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var onboardingResult = await companyUserRepository.OnboardStaffAsync(request.Dto,cancellationToken);
            if (!onboardingResult.Succeeded)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in onboardingResult.Errors)
                {
                    errors.Add(new ValidationFailure(nameof(request.Dto.EmailAddress), error.Description));
                }

                throw new ValidationException(errors);
            }

            var otp = await companyUserRepository.GenerateOtpAsync(request.Dto.EmailAddress, "verify_email");
            _ = await mailService.SendMail(request.Dto.EmailAddress, $"Your email verification OTP is {otp.Item2}. It expires in 5 min", "Verify your email");
        }
    }
}
