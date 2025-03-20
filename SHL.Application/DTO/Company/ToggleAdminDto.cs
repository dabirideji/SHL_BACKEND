using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Company
{
   public class ToggleAdminDto
    {
        public string EmailAddress { get; set; } = default!;
        public bool IsAdmin { get; set; }
    }
}
