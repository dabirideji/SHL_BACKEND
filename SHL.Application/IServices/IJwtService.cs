
using SHL.Application.DTO.Token.Request;

namespace SHL.Application.Interfaces
{
    public interface IJwtService
    {
        public string GenerateJwtToken(TokenGenerationDto tokendto) ;
        public Dictionary<string, string> ValidateJwtToken(string token);
    } 
}
