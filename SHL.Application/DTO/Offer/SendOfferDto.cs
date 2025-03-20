using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
   public class SendOfferDto
    {
        public bool MarkAsPortfolio { get; set; }
        public List<Guid> OfferIds { get; set; } = new();
    }
}
