using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.Broker
{
   public class CreateBrokerDto
    {
        public string BrokerName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string ContactPerson { get; set; } = default!;
        public string? Address { get; set; }
    }
}
