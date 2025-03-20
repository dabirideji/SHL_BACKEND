using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Dividend
{
    public class DividendPayoutRequestDto
    {
        public Guid DividendId { get; set; }
        public decimal Amount { get; set; }
    }
}
