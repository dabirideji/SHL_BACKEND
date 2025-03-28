using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Lookup
{
    public class DropdownValue : BaseModel
    {
        public long DropdownId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
