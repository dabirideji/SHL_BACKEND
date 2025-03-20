using SHL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class EquityPlan : BaseEntity, IBaseEntity
    {
        public Guid CompanyId { get ; set ; }
        public string PlanName { get; set; } = default!;
        public decimal TotalEquity { get; set; }
        public decimal Allocated { get; set; }
        public decimal UnAllocated { get; set; }
        public decimal PercentageTotalEquity { get; set; }
        public decimal PercentageAllocated { get; set; }
        public EquityType EquityType { get; set; }
        public virtual Company? Company { get; set; }
        public  ICollection<Offer> Offers { get; set; } = new HashSet<Offer>();
        public virtual ICollection<ContractDocument> ContractDocuments { get; set; } = new HashSet<ContractDocument>();
    }
}
