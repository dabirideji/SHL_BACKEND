using SHL.Application.IManagers;
using SHL.Application.Repositories;
using SHL.Repository.Repositories;

namespace SHL.Repository.Repositories
{
    public class UserVerificationRepository : GenericRepository<UserVerification>, IUserVerificationRepository
    {
        public UserVerificationRepository(ICacheManager cacheManager,SHLTennantDbContext dbContext): base(cacheManager,dbContext) 
        {
            
        }
    }
}
