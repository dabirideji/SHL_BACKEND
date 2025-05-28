using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.SendEmail
{
    public class SmsSettings
    {
        public string? SmsUsername { get; set; }
        public string? SmsApiKey { get; set; }
        public string? SmsHeader { get; set; }
        public string? Organisation { get; set; }
        public string? V2nSmsBaseUrl { get; set; }
        public string? V2nUsername { get; set; }
        public string? V2nPassword { get; set; }
    }

}
