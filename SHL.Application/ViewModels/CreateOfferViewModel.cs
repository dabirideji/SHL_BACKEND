using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.ViewModels
{
   public class CreateOfferViewModel
    {
        public Guid OfferId { get; set; }
        public Guid EquityPlanId { get; set; }
        public string Name { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public decimal Ownership { get; set; }
        public string Status { get; set; }=default!;
        public DateTime? GrantDate { get; set; }
        public DateTime VestingStartDate { get; set; }
        public DateTime VestingEndDate { get; set; }
    }
}
