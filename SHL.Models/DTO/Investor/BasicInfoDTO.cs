using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Investor
{
    public class BasicInfoDTO
    {
        public long Id { get; set; }
        public long AccountCode { get; set; }
        public string Title { get; set; }
        public long RefId { get; set; }
        public long CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? CountryOfOriginId { get; set; }
        public long? StateOfOriginId { get; set; }
        public long? LGAOfOriginId { get; set; }
        public string RelationshipManager { get; set; }
        public string IntroducerType { get; set; }
        public string Introducer { get; set; }
        public string TransactionReference { get; set; }

        public string MaidenName { get; set; }
        public string Chn { get; set; }
        public string ShareHoderTypeCode { get; set; }
        public long CompanyRegCode { get; set; }

    }

    public class BasicInfoOutputDTO : BasicInfoDTO
    { 
        public string LGAOfOrigin { get; set; }
        public string StateOfOrigin { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
