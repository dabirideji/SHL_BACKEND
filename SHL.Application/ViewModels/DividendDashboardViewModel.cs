using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
  public  class DividendDashboardViewModel
    {
        public decimal UnClaimedAmount { get; set; }
        public decimal ClaimedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalPayoutRequest { get; set; }
    }
}
