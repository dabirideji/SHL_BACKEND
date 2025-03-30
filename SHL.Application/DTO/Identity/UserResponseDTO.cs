using System;
using System.Collections.Generic;
using System.Text;

namespace SHL.Application.DTO.Identity
{
    public class UserResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsTenantAdmin { get; set; }
        public int CompanyId { get; set; }
        public int SubsidiaryId { get; set; }
        public string Token { get; set; }

    }
}
