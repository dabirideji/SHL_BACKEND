using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class TransactionHistory : BaseEntity, IBaseEntity
    {
        public Guid CompanyId { get; set; }
        public string? UserUniqueId { get; set; } 
        public string UserEmailAddress { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Source { get; set; } = default!;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
