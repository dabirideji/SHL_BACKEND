
namespace SHL.Application.Interfaces
{
    public interface IJwtService
    {
        public string GenerateJwtToken(SHL.Application.DTO.AppSetting.GenerateTokenDTO tokendto) ;
        public Dictionary<string, string> ValidateJwtToken(string token);
    } 
}
