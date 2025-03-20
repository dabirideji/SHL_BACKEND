using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Models;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Repositories
{
   public interface IOfferRepository:IGenericRepository<Offer>
    {
        Task SendOfferAsync(List<Guid> offerIds, string status);
        Task<int> SignOfferAsync(Guid offerId, string signatureUrl);
        Task<int> ChangeOfferStatusAsync(Guid offerId, string status,CancellationToken cancellationToken);
        Task<List<Offer>> CreateOffersAsync(List<OfferExcelModel> proposedOffers, EquityPlan equityPlan, decimal excercisePrice);
        Task UndoOffersAsync(List<Guid> offerId);
    }
}
