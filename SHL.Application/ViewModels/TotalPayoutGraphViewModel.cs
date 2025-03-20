using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
  public  class TotalPayoutGraphViewModel
    {
        public string Month { get; set; } = default!;
        public decimal Payout { get; set; }
    }
}
