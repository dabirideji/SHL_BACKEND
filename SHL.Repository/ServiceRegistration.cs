using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(SHL.Repository.Repositories.GenericRepositoryImplementations.GenericRepository<>));
            services.AddScoped<IUnitOfWork>(c => { return c.GetRequiredService<SHLTennantDbContext>(); });
            //services.AddScoped<TotpTokenProvider<OmniXUser>>();
            return services;
        }
    }
}
