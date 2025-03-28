using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class KycBankInfo : BaseModel
    {
        public long KycId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public long BankId { get; set; }

        public virtual Kyc Kyc { get; set; }
    }
}
