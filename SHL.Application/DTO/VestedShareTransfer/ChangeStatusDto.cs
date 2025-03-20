using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.VestedShareTransfer
{
    public class ChangeStatusDto
    {
        public List<Guid> Ids { get; set; } = new();
        public string Status { get; set; } = default!;
        public string? DeclineComment { get; set; } 
    }
}
