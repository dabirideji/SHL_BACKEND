using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Staff
{
    public class EditProfileDto
    {
        public string PhoneNumber { get; set; } = default!;
        public string? CscsNumber { get; set; }
        public string ChnNumber { get; set; } = default!;
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
    }
}
