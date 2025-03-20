using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
    public class OnboardDto
    {
        public string CompanyName { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string CompanySize { get; set; } = default!;
        public string AnnualRevenue { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string CompanyEmail { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string DomainName { get; set; } = default!;
    }
}
