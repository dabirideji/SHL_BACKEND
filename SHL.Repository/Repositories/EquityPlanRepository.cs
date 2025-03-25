
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class EquityPlanRepository : GenericRepository<EquityPlan>, IEquityPlanRepository
    {
        public EquityPlanRepository(ICacheManager cacheManager) : base(cacheManager)
        {
        }
    }
}
