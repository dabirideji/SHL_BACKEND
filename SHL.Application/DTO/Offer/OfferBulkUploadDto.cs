using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
   public class OfferBulkUploadDto
    {       
        public Guid EquityPlanId { get; set; }
        public decimal ExcercisePrice { get; set; }
        public IFormFile OfferFile { get; set; } = default!;
    }
}
