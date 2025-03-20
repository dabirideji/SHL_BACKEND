using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.VestedShareTransfer
{
   public class SendToBrokerDto
    {
        public Guid BrokerId { get; set; }
        public List<Guid> VestedSharedRequestIds { get; set; } = new();
    }
}
