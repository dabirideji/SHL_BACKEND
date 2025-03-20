
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Application.Services;
using System.Security.Claims;

namespace SHL.Api.BackgroundServices
{
    public class CreateStaffFromOfferBackgroundService : BackgroundService
    {
        private readonly IServiceProvider services;
        private readonly ILogger<CreateStaffFromOfferBackgroundService> logger;
        private readonly IOfferUserChannel offerUserChannel;

        public CreateStaffFromOfferBackgroundService(IServiceProvider services,
        ILogger<CreateStaffFromOfferBackgroundService> logger,
        IOfferUserChannel offerUserChannel)
        {
            this.services = services;
            this.logger = logger;
            this.offerUserChannel = offerUserChannel;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = services.CreateScope())
            {
                var companyUserRepository = scope.ServiceProvider.GetService<ICompanyUserRepository>();
                var mailService = scope.ServiceProvider.GetService<IMailService>();
                var configuration = scope.ServiceProvider.GetService<IConfiguration>();

                await foreach (var item in offerUserChannel.ReadAllAsync())
                {
                    try
                    {
                        if (stoppingToken.IsCancellationRequested)
                            break;

                        // Process the item
                        logger.LogInformation($"registering staff with email: {item.EmailAddress}");
                        (IdentityResult Status, Domain.Models.CompanyUser User) registrationResult = await companyUserRepository!.CreateStaffWithoutPasswordAsync(item);

                        if (registrationResult.Status.Succeeded)
                        {
                            //Save claims
                            var claims = new List<Claim>
                                        {
                                            new Claim(ClaimTypes.NameIdentifier,registrationResult.User.Id),
                                            new Claim(ClaimTypes.Email,registrationResult.User.Email!),
                                            new Claim("companyid",item.CompanyId.ToString())
                                        };
                            _ = await companyUserRepository.AddUserClaimsAsync(registrationResult.User, claims);

                            //send email
                            var token = await companyUserRepository.GeneratePasswordResetTokenAsync(item.EmailAddress, stoppingToken);

                            var baseUrl = configuration["FrontendBaseUrl"]!;
                            //var profileUpdateLink = $"{baseUrl}/employeesetup?email={item.EmailAddress}&token={token.Item2}";
                            //await mailService!.SendMail(item.EmailAddress, $"Welcome to EquityPlan, kindly click on this link to set-up your profile {profileUpdateLink}", "Welcome to SHL");

                            await companyUserRepository.SendStaffOnboardingLinkAsync(baseUrl, item.EmailAddress, token.Item2, stoppingToken);
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "");
                    }
                }
            }

        }


    }
}
