using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.ViewDto
{
    public class MessageOut
    {
        public long RetId { get; set; }
        public string TxnReference { get; set; }
        public string otp { get; set; }
        public string Message { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsFirstTimeLogin => LastLogin == null;
        public bool IsSuccessful { get; set; }
        public object data { get; set; }
        public long CompanyId { get; set; }
        public string PhoneNo { get; set; }
    }
}
