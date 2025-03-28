using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class ChangeOfAddress : BaseModel
    {
        public  long UserId { get; set; }
        public long? RequestLogId { get; set; }
        public long company_id { get; set; }
        public string OldAddress { get; set; }
        public string New_Address { get; set; }
        public string email { get; set; }
        public long? country_id { get; set; }
        public DateTime? dob { get; set; }
        public int? Acctno { get; set; }
        public short? regcode { get; set; }
    }
}
