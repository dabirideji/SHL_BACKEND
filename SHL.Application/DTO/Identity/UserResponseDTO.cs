using System;
using System.Collections.Generic;
using System.Text;

namespace SHL.Application.DTO.Identity
{
    public class UserResponseDTO
    {
        public bool toggle_notification { get; set; }
        public bool info_update_status { get; set; }
        public string user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string other_name { get; set; }
        public string full_name { get; set; }
        public string? email { get; set; }
        public string holder_type { get; set; }
        public string? phone_number { get; set; }
        public string acctno { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string bvn { get; set; }
        public string nin { get; set; }
        public string tin { get; set; }
        public string rc_number { get; set; }
        public bool is_activated { get; set; }
        public string account_details { get; set; }
        public string identity_info { get; set; }
        public string jwt_token { get; set; }
        public string profile_pic { get; set; }
        public int? company_id { get; set; }
        public DateTime lastLogin { get; set; }
        public bool isFirstTimeLogin { get; set; }
        public bool isAdmin { get; set; }
        public bool isSuperAdmin { get; set; }
        public bool isTenantAdmin { get; set; }
        public int subscriptionId { get; set; }
        public int subscriptionEnumType { get; set; }
        public int subMode { get; set; }
        public bool isFreeMode { get; set; }
        public bool isCautioned { get; set; }
        public int cosec_app_id { get; set; }
        public int CosecUserId { get; set; }
        public List<string> lstPermissions { get; set; }
        public List<string> roles { get; set; }
        public int CosecInvestmentBalance { get; set; }

    }
    
}
