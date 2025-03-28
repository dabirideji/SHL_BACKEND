using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Investor
{
    public class NextOfKin : BaseModel
    {
        public long BasicInfoId { get; set; }
        public string Title { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public long? StateId { get; set; }
        public long? CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public virtual BasicInfo BasicInfo { get; set; }
    }
}
