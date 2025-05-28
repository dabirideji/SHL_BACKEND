using Microsoft.Extensions.DependencyInjection;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using SHL.Repository.Repositories;

namespace SHL.Repository
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork>(c => { return c.GetRequiredService<SHLTennantDbContext>(); });
           
            //services.AddScoped<TotpTokenProvider<OmniXUser>>();
            return services;
        }
    }
}
