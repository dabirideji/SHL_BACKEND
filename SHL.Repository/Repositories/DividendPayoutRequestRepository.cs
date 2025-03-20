using SHL.Application.Interfaces.GenericRepositoryPattern;

namespace SHL.Repository.Repositories
{
    public class DividendPayoutRequestRepository : GenericRepository<DividendPayoutRequest>, IDividendPayoutRequestRepository
    {
        public DividendPayoutRequestRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }
    }
}
