using SHL.Application.Interfaces.GenericRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class BrokerRepository : GenericRepository<Broker>, IBrokerRepository
    {
        public BrokerRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }
    }
}
