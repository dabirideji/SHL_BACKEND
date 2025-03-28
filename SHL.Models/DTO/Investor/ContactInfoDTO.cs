using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Investor
{
    public class ContactInfoDTO
    {
        public long BasicInfoId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long? StateId { get; set; }
        public long? CountryId { get; set; }
        public string ZipCode { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string EmailAddress { get; set; }
        public string WebAddress { get; set; }
        public bool IsDefault { get; set; }
    }

    public class ContactInfoOutputDTO : ContactInfoDTO
    {
        public string State { get; set; }
        public string Country { get; set; }
    }
}
