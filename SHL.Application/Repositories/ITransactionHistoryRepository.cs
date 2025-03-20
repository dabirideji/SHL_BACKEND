using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Repositories
{
   public interface ITransactionHistoryRepository:IGenericRepository<TransactionHistory>
    {
        Task SaveOfferAsTransactionHistoryAsync(List<Guid> offerIds, string description, Guid companyId, CancellationToken cancellationToken);
    }
}
