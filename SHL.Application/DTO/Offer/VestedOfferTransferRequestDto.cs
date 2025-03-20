using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
   public class VestedOfferTransferRequestDto
    {
        public Guid OfferId { get; set; }
        public Guid BrokerId { get; set; }
        public string? CscsNumber { get; set; } 
        public string? ChnNumber { get; set; } = default!;
        public decimal TransferValue { get; set; }
    }
}
