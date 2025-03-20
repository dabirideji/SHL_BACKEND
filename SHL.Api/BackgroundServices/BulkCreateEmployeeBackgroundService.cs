
using Microsoft.AspNetCore.Identity;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Services;
using SHL.Infrastructure.Services;
using System.Security.Claims;

namespace SHL.Api.BackgroundServices
{
    public class BulkCreateEmployeeBackgroundService : BackgroundService
    {
        private readonly IServiceProvider services;
        private readonly ILogger<BulkCreateEmployeeBackgroundService> logger;
        private readonly IBulkEmployeeChannel bulkEmployeeChannel;

        public BulkCreateEmployeeBackgroundService(IServiceProvider services,
        ILogger<BulkCreateEmployeeBackgroundService> logger,
        IBulkEmployeeChannel bulkEmployeeChannel)
        {
            this.services = services;
            this.logger = logger;
            this.bulkEmployeeChannel = bulkEmployeeChannel;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = services.CreateScope())
            {
                var companyUserRepository = scope.ServiceProvider.GetService<ICompanyUserRepository>();
                var mailService = scope.ServiceProvider.GetService<IMailService>();
                var configuration = scope.ServiceProvider.GetService<IConfiguration>();

                await foreach (var item in bulkEmployeeChannel.ReadAllAsync())
                {
                    try
                    {
                        if (stoppingToken.IsCancellationRequested)
                            break;

                        // Process the item
                        logger.LogInformation($"registering staff with email: {item.EmailAddress}");
                        var staffModel = new StaffModel
                        {
                            CompanyId = item.CompanyId,
                            Designation = item.Designation,
                            EmailAddress = item.EmailAddress,
                            EmployeeId = item.EmployeeId,
                            EmploymentDate = item.EmploymentDate,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            StaffCode = "",
                            StaffDepartment = item.Department,
                            StaffGrade = item.Grade

                        };
                        (IdentityResult Status, Domain.Models.CompanyUser User) registrationResult = await companyUserRepository!.CreateStaffWithoutPasswordAsync(staffModel);

                        if (registrationResult.Status.Succeeded)
                        {
                            //Save claims
                            var claims = new List<Claim>
                                        {
                                            new Claim(ClaimTypes.NameIdentifier,registrationResult.User.Id),
                                            new Claim(ClaimTypes.Email,registrationResult.User.Email!),                                            
                                            new Claim(ClaimTypes.GivenName,item.FirstName!),
                                            new Claim(ClaimTypes.Surname,item.LastName!),
                                            new Claim("companyid",item.CompanyId.ToString())
                                        };

                            if (!string.IsNullOrEmpty(item.PhoneNumber))
                                new Claim(ClaimTypes.MobilePhone, item.PhoneNumber!);

                            _ = await companyUserRepository.AddUserClaimsAsync(registrationResult.User, claims);

                            //send email
                            var token = await companyUserRepository.GeneratePasswordResetTokenAsync(item.EmailAddress, stoppingToken);

                            var baseUrl = configuration!["FrontendBaseUrl"]!;
                            
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
