using CSL.Models.Investor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.DTO.Investor
{
    public class RegistrationDTO
    {
        public BasicInfo basicInfo { get; set; } 

    }

    public class RegistrationOutputDTO
    {
        public BasicInfoOutputDTO BasicInfo { get; set; }
        public List<ContactInfoOutputDTO> ContactInfoList { get; set; }
        //public List<BankInfoOutputDTO> BankInfoList { get; set; }
        public List<EmploymentInfo> EmploymentInfoList { get; set; }
        public List<Identification> IdentificationList { get; set; }
        public List<NextOfKinOutputDTO> NextOfKinList { get; set; }
        public List<SignatureInfo> SignatureList { get; set; }
    }

    public class RegistrationSummaryOutputDTO
    {
        public BasicInfoOutputDTO BasicInfo { get; set; }
    }

}

