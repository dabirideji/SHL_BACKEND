using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class ShareholderViewModel
    {
        public string? CscsNumber { get; set; }
        public string? ChnNumber { get; set; }
        public string? Broker { get; set; }
        public string? ShareholderName { get; set; }
        public string? ShareholderAddress { get; set; }
        public string? ShareholderEmailAddress { get; set; }
        public decimal Holding { get; set; }
        public decimal PercentageHolding { get; set; }
    }
}
