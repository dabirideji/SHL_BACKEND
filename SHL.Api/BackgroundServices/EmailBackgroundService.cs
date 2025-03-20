
using Microsoft.AspNetCore.Identity;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Application.Services;
using SHL.Infrastructure.Services;
using System.Security.Claims;

namespace SHL.Api.BackgroundServices
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IServiceProvider services;
        private readonly ILogger<EmailBackgroundService> logger;
        private readonly IOfferEmailChannel offerEmailChannel;

        public EmailBackgroundService(IServiceProvider services,
        ILogger<EmailBackgroundService> logger,
        IOfferEmailChannel offerEmailChannel)
        {
            this.services = services;
            this.logger = logger;
            this.offerEmailChannel = offerEmailChannel;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = services.CreateScope())
            {
                var mailService = scope.ServiceProvider.GetService<IMailService>();

                await foreach (var item in offerEmailChannel.ReadAllAsync())
                {
                    try
                    {
                        if (stoppingToken.IsCancellationRequested)
                            break;

                        // Process the item
                        logger.LogInformation($"Sending email for: {item.EmailAddress}");

                        await mailService!.SendMail(item.EmailAddress, item.Message, item.Subject);

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
