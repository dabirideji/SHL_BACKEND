using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
   public class CreateOfferDto
    {
        public Guid EquityPlanId { get; set; }
        public decimal OfferValue { get; set; }
        public DateTime VestStartDate { get; set; }
        public DateTime VestEndDate { get; set; }
        public decimal ExcercisePrice { get; set; }
        public List<string> EmailAddresses { get; set; } = new();
    }

}
