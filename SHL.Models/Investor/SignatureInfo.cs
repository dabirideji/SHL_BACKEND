using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class SignatureInfo : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string SignatureBase64Str { get; set; }
        public string Comment { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
