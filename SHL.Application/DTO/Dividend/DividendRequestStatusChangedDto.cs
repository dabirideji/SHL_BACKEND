using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Dividend
{
   public class DividendRequestStatusChangedDto
    {
        public List<Guid> PayoutRequestIds { get; set; } = [];
        public string Status { get; set; } = default!;
        public string? DeclineComment { get; set; } 
    }
}
