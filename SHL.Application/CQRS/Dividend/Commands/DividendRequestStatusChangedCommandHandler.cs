using FluentValidation;
using MediatR;
using SHL.Application.DTO.Dividend;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Dividend.Commands
{
    public record DividendRequestStatusChangedCommand(DividendRequestStatusChangedDto Dto) : IRequest;
    class DividendRequestStatusChangedCommandHandler : IRequestHandler<DividendRequestStatusChangedCommand>
    {
        private readonly IValidator<DividendRequestStatusChangedDto> validator;
        private readonly IDividendPayoutRequestRepository dividendPayoutRequestRepository;
        private readonly IDividendRepository dividendRepository;
        private readonly IDividendTransactionHistoryRepository dividendTransactionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferEmailChannel offerEmailChannel;

        public DividendRequestStatusChangedCommandHandler(IValidator<DividendRequestStatusChangedDto> validator,
            IDividendPayoutRequestRepository dividendPayoutRequestRepository,
            IDividendRepository dividendRepository,
            IDividendTransactionHistoryRepository dividendTransactionHistoryRepository,
            IUnitOfWork unitOfWork,
            IOfferEmailChannel offerEmailChannel)
        {
            this.validator = validator;
            this.dividendPayoutRequestRepository = dividendPayoutRequestRepository;
            this.dividendRepository = dividendRepository;
            this.dividendTransactionHistoryRepository = dividendTransactionHistoryRepository;
            this.unitOfWork = unitOfWork;
            this.offerEmailChannel = offerEmailChannel;
        }
        public async Task Handle(DividendRequestStatusChangedCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto, cancellationToken);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var status = (Domain.Enums.PayoutRequest)Enum.Parse(typeof(Domain.Enums.PayoutRequest), request.Dto.Status);
            var payoutRequests = dividendPayoutRequestRepository.Get(u => request.Dto.PayoutRequestIds.Contains(u.Id))
                 .ToList();

            var emailModels = new List<EmailModel>();
            foreach (var payout in payoutRequests)
            {
                if (payout.Status != Domain.Enums.PayoutRequest.Pending.ToString() ||
                    payout.Status != Domain.Enums.PayoutRequest.Declined.ToString())
                    continue;

                if (status == Domain.Enums.PayoutRequest.Approved)
                {
                    var dividend = await dividendRepository.GetByIdAsync(payout.DividendId);
                    dividend!.UnClaimedAmount = dividend.UnClaimedAmount - payout.Amount;
                    dividend.ClaimedAmount = dividend.ClaimedAmount + payout.Amount;
                    await dividendTransactionHistoryRepository.AddAsync(new Domain.Models.DividendTransactionHistory
                    {
                        Amount = -1 * payout.Amount,
                        DividendId = dividend.Id,
                        EmployeeEmailAddress = dividend.EmployeeEmailAddress,
                        EmployeeName = dividend.EmployeeName,
                        TransactionDate = DateTime.Now
                    });
                }
                payout.Status = status.ToString();
                payout.DeclineComment = request.Dto.DeclineComment;
                payout.UpdatedAt = DateTime.Now;
                emailModels.Add(new EmailModel
                {
                    EmailAddress = payout.EmployeeEmailAddress,
                    Message = $"Dear {payout.EmployeeName},\n\nyour payout request of {payout.Amount:N2} has been {status.ToString()}",
                    Subject = "Payout request update"
                });
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var email in emailModels)
            {
                await offerEmailChannel.QueueItemAsync(email);
            }
        }
    }
}
