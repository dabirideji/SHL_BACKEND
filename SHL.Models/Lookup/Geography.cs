using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSL.Models.Lookup
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
    }

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
    }


    public class Lga
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual State State { get; set; } = null!;
    }
}
