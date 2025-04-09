using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Identity
{
    public class CreateUserAsRetailDTO
    {
        public string? FullName { get; set; }
        public string? EmailOrPhoneNumber { get; set; }
        public string? Password { get; set; }

    }
}
