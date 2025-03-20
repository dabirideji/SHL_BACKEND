using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class StaffBank : BaseEntity
    {
        public Guid StaffId { get; set; }
        public string? BankName { get; set; } 
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; } 
        public string? SwitfCode { get; set; }

        public virtual Staff? Staff { get; set; }
    }
}
