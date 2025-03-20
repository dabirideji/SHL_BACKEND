using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SHL.Application.DTO.Company;
using SHL.Application.Repositories;
using SHL.Application.Services;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record ResendVerifyEmailCommand(ResendVerifyEmailDto Dto) :IRequest;
    class ResendVerifyEmailCommandHandler : IRequestHandler<ResendVerifyEmailCommand>
    {
        private readonly IValidator<ResendVerifyEmailDto> validator;
        private readonly UserManager<CompanyUser> userManager;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly IMailService mailService;

        public ResendVerifyEmailCommandHandler(IValidator<ResendVerifyEmailDto> validator,
            UserManager<CompanyUser> userManager,
            ICompanyUserRepository companyUserRepository,
            IMailService mailService)
        {
            this.validator = validator;
            this.userManager = userManager;
            this.companyUserRepository = companyUserRepository;
            this.mailService = mailService;
        }
        public async Task Handle(ResendVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);


            var otp = await companyUserRepository.GenerateOtpAsync(request.Dto.EmailAddress, "verify_email");
            _ = await mailService.SendMail(request.Dto.EmailAddress, $"Your email verification OTP is {otp.Item2}. It expires in 5 min", "Verify your email");
        }
    }
}
