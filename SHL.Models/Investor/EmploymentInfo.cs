using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class EmploymentInfo : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string EmployeeId { get; set; }
        public string JobTitle { get; set; }
        public string EmployerName { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerPhone { get; set; }
        public string EmployerEmail { get; set; }
        public string EmployerUrl { get; set; }
        public bool? IsCurrent { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
