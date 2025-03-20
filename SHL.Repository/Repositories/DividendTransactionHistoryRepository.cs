using SHL.Application.Interfaces.GenericRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class DividendTransactionHistoryRepository : GenericRepository<DividendTransactionHistory>, IDividendTransactionHistoryRepository
    {
        public DividendTransactionHistoryRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }
    }
}
