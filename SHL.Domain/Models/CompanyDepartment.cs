using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain.Models
{
   public class CompanyDepartment : BaseEntity, IBaseEntity
    {
        public Guid CompanyId { get ; set ; }
        public string Department { get; set; } = default!;
        public string NormalizedDepartment { get; set; } = default!;
        public virtual Company? Company { get; set; }
    }
}
