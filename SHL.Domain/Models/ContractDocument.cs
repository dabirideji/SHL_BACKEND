using SHL.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class ContractDocument : BaseEntity
    {
        public Guid EquityPlanId { get; set; }
        public string DocumentName { get; set; } = default!;
        public ContractDocumentType ContractDocumentType { get; set; }
        public string? DocumentContentUrl { get; set; }
        public string? DocumentContent { get; set; }

        public virtual EquityPlan? EquityPlan { get; set; }
    }
}
