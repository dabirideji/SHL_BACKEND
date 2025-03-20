using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Repository.Repositories
{
    public class VestedShareTransferRepository : GenericRepository<VestedShareTransfer>, IVestedShareTransferRepository
    {
        public VestedShareTransferRepository(IUnitOfWork context, ICacheManager cacheManager) : base(context, cacheManager)
        {
        }

        public async Task<int> ChangeRequestStatusAsync(List<Guid> ids, Guid companyId, string status, string? declineComment, CancellationToken cancellationToken)
        {
            var result = await _dbSet.Where(v => ids.Contains(v.Id) && v.Status == Domain.Enums.VestesShareTransfer.PendingApproval.ToString() && v.CompanyId == companyId)
                            .ExecuteUpdateAsync(s => s.SetProperty(p => p.Status, status)
                            .SetProperty(p => p.ApprovalDate, DateTime.Now)
                            .SetProperty(p=>p.DeclineComment,declineComment), cancellationToken);

            return result;
        }

        public VestedShareTransfer? UpdateVestedSharedRequestToProcess(string referenceId, string holderEmailAddress)
        {
            var vestedSharedRequest = _dbSet.Where(v => v.ReferenceNumber == referenceId && v.HolderEmailAddress == holderEmailAddress)
                .Include(o => o.Offer)
                .FirstOrDefault();

            if (vestedSharedRequest is not null)
            {
                vestedSharedRequest.ProcessedDate = DateTime.Now;
                vestedSharedRequest.Status = Domain.Enums.VestesShareTransfer.Processed.ToString();

                vestedSharedRequest.Offer!.OfferValue = vestedSharedRequest.Offer.OfferValue - vestedSharedRequest.TransferValue;
            }

            return vestedSharedRequest;
        }

        public async Task TransferShares(Offer offer, VestedOfferTransferRequestDto vestedOffer,Guid companyId)
        {           
            await _dbSet.AddAsync(new Domain.Models.VestedShareTransfer
            {               
                ChnNumber = vestedOffer.ChnNumber,
                CompanyId = companyId,
                CscsNumber = vestedOffer.CscsNumber ?? "",
                HolderEmailAddress = offer!.EquityHolderEmailAddress,
                HolderName = offer!.OfferHolder,
                OfferId = vestedOffer.OfferId,
                ReferenceNumber = Guid.NewGuid().ToString(),
                Status = Domain.Enums.VestesShareTransfer.PendingApproval.ToString(),
                TransferValue = vestedOffer.TransferValue
            });

            offer.BalanceOfferValue = offer.OfferValue - vestedOffer.TransferValue;

        }
    }
}
