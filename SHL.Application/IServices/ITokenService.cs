using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;
using SHL.Domain.Models.Categories;

namespace SHL.Application.Interfaces
{
    public interface ITokenService : IGenericService<Token, CreateTokenDto, UpdateTokenDto, ReadTokenDto> {
       Task<bool> SendToken(SendTokenDto dto,int duration=10, TokenType tokenType=TokenType.EMAIL_VERIFICATION);
                Task<bool> VerifyToken(string token, string userReferenceValue);
    }
}
