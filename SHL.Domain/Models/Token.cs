namespace SHL.Domain.Models
{
    public class Token : BaseEntity
    {
        public TokenType? TokenType { get; set; } = Categories.TokenType.EMAIL_VERIFICATION;
        public string? UserReferenceValue { get; set; }
        public string? TokenTitle { get; set; }
        public string? TokenCode { get; set; }
        public Status TokenStatus { get; set; } = Status.ACTIVE;
        public int TokenExpiryDurationInMins { get; set; }
        public DateTime TokenExpiryTime { get; set; }

    }
}