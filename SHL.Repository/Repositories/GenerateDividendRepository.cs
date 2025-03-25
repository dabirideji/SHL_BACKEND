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
    {private readonly IUnitOfWork _unitOfWork;
        public GenerateDividendRepository(IUnitOfWork context, ICacheManager cacheManager) : base(cacheManager)
        {
            _unitOfWork=context;
        }

        public async Task<int> ExecutueDeleteAsync(Guid id)
        {
            // var repo=_unitOfWork.
            var result = await _dbSet.Where(c => c.Id == id).ExecuteDeleteAsync();

            return result;
        }
    }
}
