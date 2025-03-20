using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class CreateTokenDto
    {
        public TokenType? TokenType { get; set; }
        public string? TokenTitle { get; set; }
        public string? TokenCode { get; set; }
        public int TokenExpiryDurationInMins { get; set; }
        public DateTime TokenExpiryTime { get; set; }
    }
}
