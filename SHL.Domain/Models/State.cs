using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
   
    public class State
    {
        public State()
        {
            IsActive = true;
        }
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }


        public virtual Country Country { get; set; }
        public virtual ICollection<Lga> Lgas { get; set; }
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }

}
