using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadUserCardDetailDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? CardNumber { get; set; }

        public CardType CardType { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public string? CardHolderName { get; set; }
        public string? CVV { get; set; }
        public string? BillingAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
