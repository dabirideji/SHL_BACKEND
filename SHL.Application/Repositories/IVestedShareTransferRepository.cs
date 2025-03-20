using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Repositories
{
    public interface IVestedShareTransferRepository : IGenericRepository<VestedShareTransfer>
    {
        Task TransferShares(Offer offer, VestedOfferTransferRequestDto vestedOffer, Guid companyId);
        Task<int> ChangeRequestStatusAsync(List<Guid> ids, Guid companyId, string status,string? declineComment, CancellationToken cancellationToken);
        VestedShareTransfer? UpdateVestedSharedRequestToProcess(string referenceId, string holderEmailAddress);
    }
}
