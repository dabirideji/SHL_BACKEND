using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton<IOfferUserChannel, OfferUserChannel>();
            services.AddSingleton<IOfferEmailChannel, OfferEmailChannel>();
            services.AddSingleton<IBulkEmployeeChannel, BulkEmployeeChannel>();
            return services;
        }
    }
}
