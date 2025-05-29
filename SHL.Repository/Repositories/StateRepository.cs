using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Models.Lookup;
using SHL.Application.Repositories;

namespace SHL.Repository.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(ICacheManager cacheManager, SHLTennantDbContext dbContext) : base(cacheManager, dbContext)
        {

        }
    }
}

