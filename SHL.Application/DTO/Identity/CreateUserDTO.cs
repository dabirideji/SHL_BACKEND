using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Identity
{
    public class CreateUserDTO
    {
        public string EmailOrPhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
