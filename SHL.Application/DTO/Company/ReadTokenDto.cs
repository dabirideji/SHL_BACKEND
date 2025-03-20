using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadTokenDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TokenType? TokenType { get; set; }
        public string? TokenTitle { get; set; }
        public string? TokenCode { get; set; }
        public Status TokenStatus { get; set; }
        public int TokenExpiryDurationInMins { get; set; }
        public DateTime TokenExpiryTime { get; set; }
    }
}
