using System;
using System.Collections.Generic;
using System.Text;

namespace SHL.Domain.Models
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public bool DefaultEnabled { get; set; }

        public virtual ICollection<SubscriptionFeature> SubscriptionFeatures { get; set; }
    }
}
