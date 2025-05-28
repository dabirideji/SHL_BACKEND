using Microsoft.Extensions.DependencyInjection;
using SHL.Application.DTO.SendEmail;
using SHL.Application.IServices;
using SHL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Infrastructure
{
  public static  class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
        {            
            services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();
            services.AddScoped<IExcelProcessor, ExcelProcessor>();
            services.AddHttpClient<ISmsService, SmsService>();
            services.AddScoped<IUserOnboardingService, UserOnboardingService>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IShareholderService, ShareholderService>();
            services.AddScoped<IEStockService,EStockService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IUserVerificationService, UserVerificationService>();

           

            return services;
        }
    }
}
