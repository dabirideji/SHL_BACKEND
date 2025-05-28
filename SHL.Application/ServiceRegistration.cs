using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.AppSettings;
using SHL.Application.DTO.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR((c) =>
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                 //c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                // .AddHttpClientServices(configuration)
                .AddConfigs(configuration);
            services.Configure<SmsSettings>(configuration.GetSection("Comm"));
            return services;
        }

        private static IServiceCollection AddConfigs(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<AzureBlobStorageSetting>(configuration.GetSection("AzureBlobStorageSetting"));
            return services;
        }
    }
}
