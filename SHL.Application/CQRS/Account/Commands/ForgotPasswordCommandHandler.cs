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
        private readonly IApplicationUserRepository ApplicationUserRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMailService mailService;

        public ForgotPasswordCommandHandler(IApplicationUserRepository ApplicationUserRepository,
            UserManager<ApplicationUser> userManager,
            IMailService mailService)
        {
            this.ApplicationUserRepository = ApplicationUserRepository;
            this.userManager = userManager;
            this.mailService = mailService;
        }
        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {

            (IdentityResult result, string token) result = await ApplicationUserRepository.GeneratePasswordResetTokenAsync(request.EmailAddress, cancellationToken);
            if (result.result.Succeeded)
            {
                var changePasswordUrl = $"email={request.EmailAddress}&token={result.token}";
                var status = await mailService.SendMail(request.EmailAddress, $"Reset your password by clicking on this link {changePasswordUrl}", "Reset your password");
            }
        }
    }
}
