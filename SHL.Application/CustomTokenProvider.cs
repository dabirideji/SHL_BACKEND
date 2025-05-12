using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SHL.Domain.Models.Identity;

namespace SHL.Application
{
    public class CustomTokenProvider : IUserTwoFactorTokenProvider<ApplicationUser>
    {
        private readonly ILogger<CustomTokenProvider> _logger;

        public CustomTokenProvider(ILogger<CustomTokenProvider> logger)
        {
            _logger = logger;
        }

        public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateAsync(string purpose, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            var token = new Random().Next(100000, 999999).ToString();

        
            _logger.LogInformation("Generated token for user {UserId}: {Token}", user.Id, token);

            return token;
        }


        public async Task<bool> ValidateAsync(string purpose, string token, UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            if (token.Length == 6 && token.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }

}
