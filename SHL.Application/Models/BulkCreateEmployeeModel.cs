using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Models
{
   public class BulkCreateEmployeeModel
    {
        public string? EmployeeId { get; set; }
        public string EmailAddress { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Department { get; set; }
        public string? Grade { get; set; }
        public string? EmploymentDate { get; set; }
        public string? Designation { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid CompanyId { get; set; }
    }
}
