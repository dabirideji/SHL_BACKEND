using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class EventLog 
    {
        public long Id { get; set; }
        public long BasicInfoId { get; set; }
        public string LogType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
