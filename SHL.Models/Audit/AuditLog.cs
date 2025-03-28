using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Audit
{
    public class AuditLog: BaseModel
    {
        public string LogType { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string Comment { get; set; }
        public string TransactionReference { get; set; }
       
    }
}
