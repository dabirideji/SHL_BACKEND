using MediatR;
using Microsoft.AspNetCore.Identity;
using SHL.Application.Repositories;
using SHL.Application.Services;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Account.Commands
{
    public record ForgotPasswordCommand(string EmailAddress) : IRequest;
    class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly UserManager<CompanyUser> userManager;
        private readonly IMailService mailService;

        public ForgotPasswordCommandHandler(ICompanyUserRepository companyUserRepository,
            UserManager<Domain.Models.CompanyUser> userManager,
            IMailService mailService)
        {
            this.companyUserRepository = companyUserRepository;
            this.userManager = userManager;
            this.mailService = mailService;
        }
        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {

            (IdentityResult result, string token) result = await companyUserRepository.GeneratePasswordResetTokenAsync(request.EmailAddress, cancellationToken);
            if (result.result.Succeeded)
            {
                var changePasswordUrl = $"email={request.EmailAddress}&token={result.token}";
                var status = await mailService.SendMail(request.EmailAddress, $"Reset your password by clicking on this link {changePasswordUrl}", "Reset your password");
            }
        }
    }
}
