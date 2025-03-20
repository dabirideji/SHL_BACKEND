using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class EmployeeOfferDashboard
    {
        public decimal TotalOwnership { get; set; }
        public decimal VestedShares { get; set; }
        public decimal UnVestedShares { get; set; }
        public decimal UnAllocated { get; set; }
        public int EquityCount { get; set; }
    }
}
