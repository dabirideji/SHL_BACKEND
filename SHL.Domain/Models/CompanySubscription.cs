using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class CompanySubscription : BaseEntity
    {
        [ForeignKey("CompanySubscriptionCompany")]
        public Guid CompanySubscriptionCompanyId { get; set; }
        public Company? CompanySubscriptionCompany { get; set; }

        [ForeignKey("CompanySubscriptionSubscription")]
        public Guid CompanySubscriptionSubscriptionId { get; set; }
        public Subscription? CompanySubscriptionSubscription { get; set; }

        public DateTime? CompanySubscriptionBilledDate { get; set; }
        public DateTime? CompanySubscriptionExpiryDate { get; set; }
        public DateTime? CompanySubscriptionNextBilledDate { get; set; }
        public CompanySubscriptionRenewalType? CompanySubscriptionRenewalType { get; set; }
        public CompanySubscriptionStatus? CompanySubscriptionStatus { get; set; }
    }

}