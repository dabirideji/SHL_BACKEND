using System;
using System.Collections.Generic;
using System.Text;

namespace SHL.Domain.Models
{
    public class SubscriptionFeature : BaseModel
    {
        public long SubscriptionId { get; set; }
        public long FeatureId { get; set; }
        public DateTime? LastDateModified { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
