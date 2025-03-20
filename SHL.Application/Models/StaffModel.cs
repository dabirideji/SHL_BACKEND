using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Models
{
   public class StaffModel
    {
        public Guid CompanyId { get; set; }
        public string EmailAddress { get; set; } = default!;
        public string? StaffCode { get; set; }
        public string? StaffDepartment { get; set; }
        public string? StaffGrade { get; set; }
        public string? EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmploymentDate { get; set; }
        public string? Designation { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
