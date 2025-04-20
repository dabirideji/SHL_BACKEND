using Microsoft.IdentityModel.Tokens;
using SHL.Application.DTO.JWTConfiguration;
using SHL.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SHL.Application.Interface.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IAppSettingAccessor _appSettingAccessor;

        public JwtService(IAppSettingAccessor appSettings)
        {
            _appSettingAccessor = appSettings;
        }

        public string GenerateJwtToken(SHL.Application.DTO.AppSetting.GenerateTokenDTO tokendto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var expiryDuration = _appSettingAccessor.GetValue("JWTCredentials", "TokenExpiryTime");
            var secretKey = _appSettingAccessor.GetValue("JWTCredentials", "SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = GenerateClaims(tokendto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = claims,
                Subject = new ClaimsIdentity(new[] { new Claim(JWT_CONSTANTS.ClientId, tokendto.CompanyCode) }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _appSettingAccessor.GetValue("JWTCredentials", "IssuerName"),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(expiryDuration)), // Use configurable expiry time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private Dictionary<string, object> GenerateClaims(SHL.Application.DTO.AppSetting.GenerateTokenDTO tokendto)
        {
            var claims = new Dictionary<string, object>();

            foreach (var prop in tokendto.GetType().GetProperties())
            {
                var claimValue = prop.GetValue(tokendto);
                if (claimValue != null)
                {
                    claims[prop.Name] = claimValue;
                }
            }
            return claims;
        }

        public Dictionary<string, string> ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _appSettingAccessor.GetValue("JWTCredentials", "SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                tokenHandler.ValidateToken(token, tokenValidationParams, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userDecryptedData = jwtToken.Claims
                    .ToDictionary(c => c.Type, c => c.Value);

                return userDecryptedData;
            }
            catch
            {
                throw; // You can add more specific error handling here
            }
        }
    }
}
