using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
   public class CreateEmployeeDto
    {
        public string StaffCode { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? Department { get; set; }
        public string? Designation { get; set; }
        //public string? BankName { get; set; } 
        //public string? AccountNumber { get; set; }
        //public string? SwitfCode { get; set; } 

    }
}
