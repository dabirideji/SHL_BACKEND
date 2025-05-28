using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.ShareHoder
{
    public class ShareholderUpdateFormDto
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone_no { get; set; }
        public string? Confirm_Phone_no { get; set; }
        public string? bvn { get; set; }
        public string? next_of_kin { get; set; }
        public DateTime? dob { get; set; }
        public string? dobString { get; set; }
        public string? Sex { get; set; }
    }
}
