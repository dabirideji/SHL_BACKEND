using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class Subscription : BaseModel
    {
        public Subscription()
        {
            SubscriptionFeatures = new HashSet<SubscriptionFeature>();
        }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int DurationInMonths { get; set; }
        public bool DefaultEnabled { get; set; }
        public int EnumType { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<SubscriptionFeature> SubscriptionFeatures { get; set; }
    }
}
