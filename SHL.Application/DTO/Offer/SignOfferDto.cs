using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Offer
{
    public class SignOfferDto
    {
        public Guid OfferId { get; set; }
        public IFormFile Signature { get; set; } = default!;
    }
}
