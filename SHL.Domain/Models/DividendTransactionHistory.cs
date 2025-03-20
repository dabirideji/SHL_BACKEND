using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class DividendTransactionHistory : BaseEntity
    {
        public Guid DividendId { get; set; }
        public string EmployeeEmailAddress { get; set; } = default!;
        public string EmployeeName { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Dividend? Dividend { get; set; }
    }
}
