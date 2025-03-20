namespace SHL.Application.DTO.Company.Request
{
    public class ReadSubscriptionDto
    {
        public string? SubscriptionName { get; set; }
        public string? SubscriptionCode { get; set; }
        public string? SubscriptionDescription { get; set; }
        public double SubscriptionPrice { get; set; }
    }
}
