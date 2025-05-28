using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.SendEmail
{
    public class SmsMessage
    {
        public string? id { get; set; }
        public string? receiver { get; set; }
        public string? sender { get; set; }
        public string? message { get; set; }
        public string? type { get; set; }
    }
    public class SmsRequest
    {
        public List<SmsMessage> sms { get; set; }
    }
    public class SmsBatchPayload
    {
        public string Username { get; set; }
        public string ApiKey { get; set; }
        public string Sender { get; set; }
        public List<SmsMessage> sms { get; set; }
    }
}
