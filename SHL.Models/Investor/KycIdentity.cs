using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class KycIdentity :  BaseModel
    {
        public long KycId { get; set; }
        public string Signature { get; set; }
        public string ValidId { get; set; }
        public DateTime? ValidId_ExpDate { get; set; }
        public string ValidId_Number { get; set; }
        public string ValidId_Name { get; set; }


        public virtual Kyc Kyc { get; set; }
    }
}
