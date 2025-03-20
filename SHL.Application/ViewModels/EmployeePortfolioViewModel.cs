using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class EmployeePortfolioViewModel
    {
        public ShareholderViewModel? Share { get; set; }
        public decimal TotalGranted { get; set; }
        public List<Portfolio> Portfolios { get; set; } = new();
    }

    public class Portfolio
    {
        public string EquityType { get; set; } = default!;
        public decimal Granted { get; set; }
        public decimal Vested { get; set; }
        public decimal UnVested { get; set; }
    }
}
