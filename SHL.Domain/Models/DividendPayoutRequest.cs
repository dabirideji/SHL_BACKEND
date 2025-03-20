using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class DividendPayoutRequest : BaseEntity
    {
        public Guid DividendId { get; set; }
        public string EmployeeEmailAddress { get; set; } = default!;
        public string EmployeeName { get; set; } = default!;
        public decimal Amount { get; set; }
        public string Status { get; set; } = default!;
        public string? DeclineComment { get; set; } 
    }
}
