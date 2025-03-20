
using Microsoft.EntityFrameworkCore;
using SHL.Application.Models;

namespace SHL.Repository.Repositories
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(SHLTennantDbContext context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

        public async Task SendOfferAsync(List<Guid> offerIds, string status)
        {
            var offers = await this._dbSet.Where(x => offerIds.Contains(x.Id))
                .Include(c => c.EquityPlan)
                .ToListAsync();

            foreach (var offer in offers)
            {
                offer.Status = status;
                offer.EquityPlan!.Allocated = offer.EquityPlan.Allocated + offer.OfferValue;
                offer.EquityPlan.UnAllocated = offer.EquityPlan.TotalEquity - offer.EquityPlan.Allocated;
                offer.EquityPlan.PercentageAllocated = (offer.EquityPlan.Allocated / offer.EquityPlan.TotalEquity) * 100.0M;
            }         

        }

        public async Task<int> SignOfferAsync(Guid offerId, string signatureUrl)
        {
            var result = await this._dbSet.Where(x => offerId == x.Id)
                 .ExecuteUpdateAsync(o => o.SetProperty(x => x.SignatureUrl, signatureUrl)
                 .SetProperty(s => s.SignedDate, DateTime.Now)
                 .SetProperty(s => s.IsOfferSigned, true)
                 .SetProperty(s => s.Status, Domain.Enums.Offer.Vesting.ToString()));

            return result;
        }

        public async Task<int> ChangeOfferStatusAsync(Guid offerId, string status, CancellationToken cancellationToken)
        {
            var result = await this._dbSet.Where(x => offerId == x.Id)
                .ExecuteUpdateAsync(o => o.SetProperty(x => x.Status, status), cancellationToken);

            return result;
        }

        public async Task<List<Offer>> CreateOffersAsync(List<OfferExcelModel> proposedOffers, EquityPlan equityPlan,decimal excercisePrice)
        {
            var totalAllocatedUnits = proposedOffers.Sum(s => decimal.Parse(s.AllocatedUnits!));

            var offers = proposedOffers.Select(o => new Domain.Models.Offer
            {
                EquityPlanId = equityPlan.Id,
                OfferHolder = o.Name!,
                EquityHolderEmailAddress = o.Email!,
                EquityHolderUniqueId = o.UniqueId,
                OfferValue = decimal.Parse(o.AllocatedUnits!),
                BalanceOfferValue = decimal.Parse(o.AllocatedUnits!),
                EstimatedOfferValue = CalculateOwnershipPercentage(equityPlan.TotalEquity, decimal.Parse(o.AllocatedUnits!)),
                VestStartDate = DateTime.Parse(o.DateIssued!),
                VestEndDate = DateTime.Parse(o.VestingDate!),
                VestingPeriod = CalculateVestingPeriod(DateTime.Parse(o.DateIssued!), DateTime.Parse(o.VestingDate!)),
                GrantDate = DateTime.Now,
                Status = Domain.Enums.Offer.Pending.ToString(),
                ExcercisePrice = excercisePrice
            }).ToList();

            await this.AddRangeAsync(offers);

            //equityPlan.Allocated = equityPlan.Allocated + totalAllocatedUnits;
            //equityPlan.UnAllocated = equityPlan.TotalEquity - equityPlan.Allocated;
            //equityPlan.PercentageAllocated = (equityPlan.Allocated / equityPlan.TotalEquity) * 100.0M;

            return offers;
        }


        public async Task UndoOffersAsync(List<Guid> offerId)
        {
            var offers = await _dbSet.Where(o => offerId.Contains(o.Id) && o.Status == Domain.Enums.Offer.Pending.ToString())
                .ExecuteDeleteAsync();
                                          
        }

        decimal CalculateOwnershipPercentage(decimal totalUnits, decimal allocatedOffer)
        {
            var ownershipValue = (allocatedOffer / totalUnits) * 100.0M;
            return Math.Round(ownershipValue, 2);
        }

        double CalculateVestingPeriod(DateTime vestingStartDate, DateTime vestingEndDate)
        {
            var days = (vestingEndDate - vestingStartDate).TotalDays;

            return days;
        }
    }
}
