using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class Dividend : BaseEntity
    {
        public Guid GenerateDividendId { get; set; }
        public Guid EquityId { get; set; }
        public string EquityPlanName { get; set; } = default!;
        public string EmployeeEmailAddress { get; set; } = default!;
        public string EmployeeName { get; set; }=default!;
        public decimal OfferValue { get; set; }
        public decimal DividendValue { get; set; }
        public decimal UnClaimedAmount { get; set; }
        public decimal ClaimedAmount { get; set; }
        public string Status { get; set; } = default!;
        public decimal TaxInPercentage { get; set; }
        public virtual GenerateDividend? GenerateDividend { get; set; }
        public virtual ICollection<DividendTransactionHistory> DividendTransactionHistories { get; set; } = new HashSet<DividendTransactionHistory>();

    }
}
