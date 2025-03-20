using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Models
{
   public class VestedShareTransferModel
    {
        public string HolderEmailAddress { get; set; } = default!;
        public string HolderName { get; set; } = default!;
        public decimal TransferValue { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ReferenceNumber { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
