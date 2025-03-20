using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class ClaimUnClaimTrendOverTimeGraphViewModel
    {
        public string Month { get; set; } = default!;
        public decimal Paid { get; set; }
        public decimal UnPaid { get; set; }
    }
}
