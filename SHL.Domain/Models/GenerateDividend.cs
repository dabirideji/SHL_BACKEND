using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class GenerateDividend:BaseEntity
    {
        public Guid EquityId { get; set; }
        public string EquityName { get; set; } = default!;
        public decimal DividendPerShare { get; set; }
        public decimal TaxInPercentage { get; set; }

        public virtual ICollection<Dividend> Dividends { get; set; } = new HashSet<Dividend>();
    }
}
