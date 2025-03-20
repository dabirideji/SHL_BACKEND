using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SHL.Application.IServices;
using SHL.Domain.Models;
using SHL.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Infrastructure
{
    public class UserValidator : IUserValidator<CompanyUser>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserIdentityService userIdentityService;
        private readonly SHLMasterDbContext SHLMasterDbContext;

        public UserValidator(IHttpContextAccessor httpContextAccessor,
            IUserIdentityService userIdentityService,
            SHLMasterDbContext SHLMasterDbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userIdentityService = userIdentityService;
            this.SHLMasterDbContext = SHLMasterDbContext;
        }
        public Task<IdentityResult> ValidateAsync(UserManager<CompanyUser> manager, CompanyUser user)
        {

            if (httpContextAccessor.HttpContext is not null && httpContextAccessor.HttpContext!.User!.Identity!.IsAuthenticated)
            {
                var companyId = userIdentityService.CompanyId;
                var companyDomainName = SHLMasterDbContext.CompanyInfo.Where(c => c.Id == companyId)
                    .Select(s => s.NormalizedDomainName)
                    .FirstOrDefault();

                var emailDomain = user.UserName!.Split("@")[1];

                if (!string.Equals(companyDomainName, emailDomain, StringComparison.OrdinalIgnoreCase))
                {
                    return Task.FromResult(IdentityResult.Failed([new IdentityError() { Code = "InvalidDomain", Description = "email address does not belong to registered domain name" }]));
                }
            }
            else
            {
                if (httpContextAccessor.HttpContext is not null && httpContextAccessor.HttpContext!.Request.Headers.TryGetValue("x-domain", out var xDomain))
                {
                    var companyDomainName = SHLMasterDbContext.CompanyInfo.Where(c => c.NormalizedDomainName == xDomain!.FirstOrDefault()!.ToUpperInvariant())
                    .Select(s => s.NormalizedDomainName)
                    .FirstOrDefault();

                    if (string.IsNullOrEmpty(companyDomainName)) return Task.FromResult(IdentityResult.Success);//company is yet to onboard

                    var emailDomain = user.UserName!.Split("@")[1];

                    if (!string.Equals(companyDomainName, emailDomain, StringComparison.OrdinalIgnoreCase))
                    {
                        return Task.FromResult(IdentityResult.Failed([new IdentityError() { Code = "InvalidDomain", Description = "email address does not belong to registered domain name" }]));
                    }
                }

               
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
