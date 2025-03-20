using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Staff
{
    public class StaffOnboardingDto
    {
        public string EmployeeId { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string BankName { get; set; } = default!;
        public string AccountNumber { get; set; } = default!;
        public string SwitfCode { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string? Designation { get; set; }
        public string? Department { get; set; }
    }
}
