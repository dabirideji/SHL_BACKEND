using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
    public class Lga
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual State State { get; set; } = null!;
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
