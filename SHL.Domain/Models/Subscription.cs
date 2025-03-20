namespace SHL.Domain.Models
{
    public class Subscription : BaseEntity
    {
        public string? SubscriptionName { get; set; }
        public string? SubscriptionCode { get; set; }
        public string? SubscriptionDescription { get; set; }
        public double SubscriptionPrice { get; set; }
    }
}