using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.DTO.ExcerciseRequest
{
    public class ChangeRequestStatusDto
    {
        public List<Guid> ExerciseRequestId { get; set; } = new List<Guid>();
        public string Status { get; set; } = default!;
        public string? DeclineReason { get; set; }
    }
}
