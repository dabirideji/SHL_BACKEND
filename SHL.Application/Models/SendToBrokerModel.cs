using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Models
{
  public  class SendToBrokerModel
    {
        public string HolderName { get; set; } = default!;
        public string HolderEmail { get; set; } = default!;
        public decimal TransferValue { get; set; } = default!;
        public string? ChnNumber { get; set; }
        public string? CscsNumber { get; set; }
        public string ReferenceNumber { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
