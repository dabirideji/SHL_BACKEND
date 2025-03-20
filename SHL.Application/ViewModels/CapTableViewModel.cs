using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class CapTableViewModel
    {
        public int StakeHolders { get; set; }
        public decimal TotalSecurity { get; set; }

        public List<AllocatedSecurity> AllocatedSecurity { get; set; } = new();
        public List<UnAllocatedSecurity> UnAllocatedSecurity { get; set; } = new();
    }

    public class AllocatedSecurity
    {
        public string EquityType { get; set; } = default!;
        public decimal Total { get; set; }
        public decimal EquityTypePercentage { get; set; }

    }

    public class UnAllocatedSecurity
    {
        public string EquityType { get; set; } = default!;
        public decimal Total { get; set; }
        public decimal EquityTypePercentage { get; set; }

    }
}
