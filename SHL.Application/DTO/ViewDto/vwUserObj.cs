using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.DTO;

namespace SHL.Application.DTO.ViewDto
{
    public class vwUserObj : MessageOut
    {
        public vwUserObj()
        {
            account_details = new List<BankInfoDTO>();
            identity_info = new List<IdentityInfoDTO>();
        }
        public long user_id { get; set; }
        public long holder_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string other_name { get; set; }
        public string full_name => last_name + " " + first_name + " " + other_name;
        public string email { get; set; }
        public string Holder_type { get; set; }
        public string phone_number { get; set; }
        public int acctno { get; set; }
        public string chn { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string title { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string bvn { get; set; }
        public string nin { get; set; }
        public string tin { get; set; }
        public string rc_number { get; set; }
        public decimal total_valuation { get; set; }
        public string mobile_verify_otp { get; set; }
        public string otp { get; set; }
        public bool email_confirmed { get; set; }
        public bool mobile_enabled { get; set; }
        public bool is_activated { get; set; }
        public string verify_password { get; set; }
        public string verify_message { get; set; }
        public List<BankInfoDTO> account_details { get; set; }
        public List<IdentityInfoDTO> identity_info { get; set; }
        public string signature { get; set; }
        public string valid_ID { get; set; }
        public string session_token { get; set; }
        public string jwt_token { get; set; }
        public string user_token { get; set; }
        public string profile_pic { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public int sub_id { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsTenantAdmin { get; set; }
        public long? SubscriptionId { get; set; }
        public int SubscriptionEnumType { get; set; }
        public long subMode { get; set; }
        public bool IsFreeMode { get; set; }
        public bool IsCautioned { get; set; }
        public List<string> lstPermissions { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerifyLinkActive { get; set; } = true;
        public string response_code { get; set; }
        public string source { get; set; }

        public bool? isNominee { get; set; }
        public string nomineeEmail { get; set; }
        public bool CosecAccountConsent { get; set; }

        public bool info_update_status { get; set; }
    }
}
