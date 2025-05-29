using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.Repositories;

namespace SHL.Repository.Repositories
{
    public class LgaRepository : GenericRepository<Lga>, ILgaRepository
    {
        public LgaRepository(ICacheManager cacheManager, SHLTennantDbContext dbContext) : base(cacheManager, dbContext)
        {

        }
    }
}
