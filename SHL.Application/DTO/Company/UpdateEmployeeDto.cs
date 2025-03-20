using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
   public class UpdateEmployeeDto
    {
        public string StaffCode { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? StaffDepartment { get; set; }
        public string? StaffGrade { get; set; }
        public string? CscsNumber { get; set; }
        public string? ChnNumber { get; set; }
    }
}
