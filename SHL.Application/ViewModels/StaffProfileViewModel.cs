using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class StaffProfileViewModel
    {
        public string? StaffCode { get; set; }
        public string? StaffDepartment { get; set; }
        public string? StaffGrade { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? CscsNumber { get; set; }
        public string? ChnNumber { get; set; }
        public string? StaffStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BankName { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
