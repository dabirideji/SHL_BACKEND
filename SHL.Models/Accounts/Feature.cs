using System;
using System.Collections.Generic;
using System.Text;

namespace CSL.Models.Accounts
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public bool DefaultEnabled { get; set; }

        public virtual ICollection<SubscriptionFeature> SubscriptionFeatures { get; set; }
    }
}
