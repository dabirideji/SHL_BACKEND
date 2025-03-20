// using Microsoft.IdentityModel.Tokens;
// using SHL.Application.DTO.JWTConfiguration;
// using SHL.Application.DTO.Token.Request;
// using SHL.Application.Interfaces;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;

// namespace SHL.Application.Interface.Jwt
// {
//     public class JwtService : IJwtService
//     {
//         private readonly IAppSettingAccessor _appSettingAccessor;

//         public JwtService(IAppSettingAccessor appSettings)
//         {
//             _appSettingAccessor = appSettings;
//         }

//         public string GenerateJwtToken(TokenGenerationDto tokendto)
//         {
//             var tokenHandler = new JwtSecurityTokenHandler();
//             var expiryDuration = _appSettingAccessor.GetValue("JWTCredentials", "TokenExpiryTime");
//             var secretKey = _appSettingAccessor.GetValue("JWTCredentials", "SecretKey");
//             var key = Encoding.ASCII.GetBytes(secretKey);
//             List<Claim> claims = new List<Claim>()
//             {
//                 new Claim(JWT_CONSTANTS.CompanyCode,tokendto.CompanyCode),
//                 new Claim(JWT_CONSTANTS.UserType,tokendto.UserType),
//                 new Claim(JWT_CONSTANTS.UserName,tokendto.UserName),
//                 new Claim(JWT_CONSTANTS.EmailAddress,tokendto.EmailAddress),
//             };

//             var tokenDescriptor = new SecurityTokenDescriptor
//             {
//                 Claims = claims.ToDictionary(c => c.Type, c => (object)c.Value),
//                 Subject = new ClaimsIdentity(new[] { new Claim(JWT_CONSTANTS.ClientId, tokendto.CompanyCode) }),
//                 IssuedAt = DateTime.UtcNow,
//                 Issuer = _appSettingAccessor.GetValue("JWTCredentials", "IssuerName"),
//                 Expires = DateTime.UtcNow.AddMinutes(2880),
//                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
//             };
//             var token = tokenHandler.CreateToken(tokenDescriptor);
//             var userToken = tokenHandler.WriteToken(token);
//             return userToken;
//         }

//         public Dictionary<string, string> ValidateJwtToken(string token)
//         {
//             if (token == null)
//                 return null;

//             var tokenHandler = new JwtSecurityTokenHandler();
//             var secretKey = _appSettingAccessor.GetValue("JWTCredentials", "SecretKey");
//             var key = Encoding.ASCII.GetBytes(secretKey);
//             try
//             {
//                 tokenHandler.ValidateToken(token, new TokenValidationParameters
//                 {
//                     ValidateIssuerSigningKey = true,
//                     IssuerSigningKey = new SymmetricSecurityKey(key),
//                     ValidateIssuer = false,
//                     ValidateAudience = false,
//                     ClockSkew = TimeSpan.Zero
//                 }, out SecurityToken validatedToken);

//                 var jwtToken = (JwtSecurityToken)validatedToken;
//                 var CompanyCode = jwtToken.Claims.First(x => x.Type == JWT_CONSTANTS.CompanyCode).Value;
//                 var UserId = jwtToken.Claims.First(x => x.Type == JWT_CONSTANTS.UserId).Value;
//                 var ClientId = jwtToken.Claims.First(x => x.Type == JWT_CONSTANTS.ClientId).Value;
//                 var SubscriptionExpiry = jwtToken.Claims.First(x => x.Type == "ExpiryDate").Value;
//                 var userDecryptedData = new Dictionary<string, string>
//                 {
//                     { "CompanyCode", CompanyCode },
//                     { "UserId", UserId },
//                     { "ClientId", ClientId },
//                     { "ExpiryDate", SubscriptionExpiry }
//                 };
//                 return userDecryptedData;
//             }
//             catch
//             {
//                 throw;
//             }
//         }
//     }
// }





































using Microsoft.IdentityModel.Tokens;
using SHL.Application.DTO.JWTConfiguration;
using SHL.Application.DTO.Token.Request;
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

        public string GenerateJwtToken(TokenGenerationDto tokendto)
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

        private Dictionary<string, object> GenerateClaims(TokenGenerationDto tokendto)
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
