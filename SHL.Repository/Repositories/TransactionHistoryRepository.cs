
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class TransactionHistoryRepository : GenericRepository<TransactionHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(SHLTennantDbContext context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

        public async Task SaveOfferAsTransactionHistoryAsync(List<Guid> offerIds, string description, Guid companyId, CancellationToken cancellationToken)
        {
            var offerEntity = _context.Set<Offer>();
            var offers = offerEntity.Where(c => offerIds.Contains(c.Id))
                .Include(c=>c.EquityPlan).ToList();

            foreach (var offer in offers)
            {
                var source = offer.EquityPlan!.EquityType.ToString();
                await _dbSet.AddAsync(new TransactionHistory
                {
                    CompanyId = companyId,
                    Amount = offer.OfferValue,
                    UserUniqueId = offer.EquityHolderUniqueId,
                    Description =  $"{source} {description}",
                    CreatedAt = DateTime.Now,
                    TransactionDate = DateTime.Now,
                    UserEmailAddress = offer.EquityHolderEmailAddress,
                    Source = source
                });
            }
        }
    }
}
