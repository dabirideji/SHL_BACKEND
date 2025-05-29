using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.Repositories;

namespace SHL.Repository.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ICacheManager cacheManager, SHLTennantDbContext dbContext) : base(cacheManager, dbContext)
        {

        }
    }
}
