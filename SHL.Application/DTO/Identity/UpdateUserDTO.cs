using System;
using System.Collections.Generic;
using System.Text;

namespace SHL.Application.DTO.Identity
{
    public class UpdateUserDTO
    {
        public int DefaultAcctNo { get; set; }
        public string? CustomerNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherName { get; set; }
        public string? BVN { get; set; }
        public string? NIN { get; set; }
        public string? TIN { get; set; }
        public string? RC_No { get; set; }
        public string? Email { get; set; }
        public string? Phone_no { get; set; }
        public string? Source { get; set; }
        public string? InfoUpdateStatus { get; set; }
        public string? Sex { get; set; }
        public DateTime? Dob { get; set; }

    }
    public class UpdateBVNAndNINDTO
    {
        public string? BVN { get; set; }
        public string? NIN { get; set; }
    }
    public class UpdateAddressDTO
    {
        public int? CountryId { get; set; }
        public string? Street { get; set; }
        public int? LgaId { get; set; }
        public int? StateId { get; set; }
        public string? ZipCode { get; set; }
        

    }
}
