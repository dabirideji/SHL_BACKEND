using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class Country
    {
        public Country()
        {
            States = new HashSet<State>();
            IsActive = true;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DialingCode { get; set; }
        public string FlagUrl { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<State> States { get; set;}
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }

}
