namespace SHL.Application.DTO.Company.Request
{
    public class UpdateSubscriptionDto
    {
        public Guid Id { get; set; }
        public string? SubscriptionName { get; set; }
        public string? SubscriptionCode { get; set; }
        public string? SubscriptionDescription { get; set; }
        public double SubscriptionPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
