using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.GenerateDividend
{
   public class GenerateDividendDto
    {
        public Guid EquityId { get; set; }
        public decimal DividendPerShare { get; set; }
        public decimal TaxInPercentage { get; set; }
    }
}
