using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
   public class VerifyEmailDto
    {
        public string EmailAddress { get; set; } = default!;
        public string Otp { get; set; } = default!;
    }
}
