using Microsoft.EntityFrameworkCore;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.ViewModels;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class ShareholderRepository : GenericRepository<Shareholder>, IShareholderRepository
    {
        public ShareholderRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

        public async Task<ShareholderViewModel?> GetShareholderByEmailAsync(string emailAddress)
        {
            var brokerEntity = this._context.Set<Broker>();

            var shareholder = await (from s in _dbSet
                                     join b in brokerEntity on s.BrokerId equals b.Id
                                     where s.ShareholderEmailAddress == emailAddress
                                     select new ShareholderViewModel
                                     {
                                         Broker = b.BrokerName,
                                         ChnNumber = s.ChnNumber,
                                         CscsNumber = s.CscsNumber,
                                         Holding = s.Holding,
                                         PercentageHolding = s.PercentageHolding,
                                         ShareholderAddress = s.ShareholderAddress,
                                         ShareholderEmailAddress = s.ShareholderEmailAddress,
                                         ShareholderName = s.ShareholderName
                                     }).FirstOrDefaultAsync();

            return shareholder;

        }
    }
}
