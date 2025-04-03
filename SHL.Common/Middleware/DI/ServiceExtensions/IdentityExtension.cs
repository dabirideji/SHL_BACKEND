using CSL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using SHL.Domain.Models;
using SHL.Infrastructure;
using SHL.Repository.Data.Context;

namespace SHL.Api.Middleware.DI.ServiceExtensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;

            })
              .AddUserManager<UserManager<ApplicationUser>>()
              .AddSignInManager<SignInManager<ApplicationUser>>()
              .AddUserValidator<UserValidator>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<SHLTennantDbContext>()
              .AddDefaultTokenProviders()
              .AddTotpTokenProvider();

            return services;
        }
    }
}
