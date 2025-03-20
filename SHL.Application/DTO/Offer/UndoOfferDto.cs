using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
    public class UndoOfferDto
    {
        public List<Guid> OfferIds { get; set; } = new();
    }
}
