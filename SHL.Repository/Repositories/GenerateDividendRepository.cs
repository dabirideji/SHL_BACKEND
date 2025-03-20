using Microsoft.EntityFrameworkCore;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class GenerateDividendRepository : GenericRepository<GenerateDividend>, IGenerateDividendRepository
    {
        public GenerateDividendRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

        public async Task<int> ExecutueDeleteAsync(Guid id)
        {
            var result = await _dbSet.Where(c => c.Id == id).ExecuteDeleteAsync();

            return result;
        }
    }
}
