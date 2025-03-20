using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class VestedShareTransfer : BaseEntity, IBaseEntity
    {
        public Guid CompanyId { get ; set ; }
        public string HolderEmailAddress { get; set; } = default!;
        public string HolderName { get; set; } = default!;
        public Guid OfferId { get; set; }
        public decimal TransferValue { get; set; }
        public string? CscsNumber { get; set; } = default!;
        public string? ChnNumber { get; set; }
        public Guid? BrokerId { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ReferenceNumber { get; set; } = default!;
        public string Status { get; set; } = default!;
        public string? DeclineComment { get; set; }

        public virtual Offer? Offer { get; set; }
    }
}
