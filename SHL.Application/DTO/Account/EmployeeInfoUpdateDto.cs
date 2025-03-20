using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Account
{
   public class EmployeeInfoUpdateDto
    {
        public string EmailAddress { get; set; } = default!;
        public string Token { get; set; } = default!;
        //public string FirstName { get; set; } = default!;
        //public string LastName { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }
}
