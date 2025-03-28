using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Lookup
{
    public class Company : BaseModel
    {
        public int RegCode { get; set; }
        public int CoyNo { get; set; }
        public string CoyName { get; set; }
        public string SecType { get; set; }
        public string CoyAddress { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
    }
}
