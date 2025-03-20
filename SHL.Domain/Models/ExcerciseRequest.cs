using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
   public class ExcerciseRequest:BaseEntity
    {
        public Guid OfferId { get; set; }
        public string HolderName { get; set; } = default!;
        public string HolderEmailAddress { get; set; } = default!;
        public string PlanName { get; set; } = default!;
        public string? PaymentReference { get; set; }
        public int Amount { get; set; }
        public decimal ExercisePrice { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } = default!;
        public string? DeclineReason { get; set; } 

        public virtual Offer? Offer { get; set; }
    }
}
