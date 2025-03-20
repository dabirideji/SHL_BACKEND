using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Domain
{
    public interface IBaseEntity
    {
        public Guid CompanyId { get; set; }
    }
}
