using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class Kyc : BaseModel
    {
        public Kyc()
        {
            KycBankInfos = new HashSet<KycBankInfo>();
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Holder_type { get; set; }
        public string BVN { get; set; }
        public string NIN { get; set; }
        public string TIN { get; set; }
        public string RC_NO { get; set; }
        public string Signature { get; set; }
        public string ValidID { get; set; }

        public virtual ICollection<KycBankInfo> KycBankInfos { get; set; }
        public virtual ICollection<KycIdentity> KycIdentities { get; set; }
    }
}
