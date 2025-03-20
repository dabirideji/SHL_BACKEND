using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.GenerateDividend;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.GenerateDividend.Commands
{
    public record GenerateDividendCommand(GenerateDividendDto Dto) : IRequest;
    class GenerateDividendCommandHandler : IRequestHandler<GenerateDividendCommand>
    {
        private readonly IValidator<GenerateDividendDto> validator;
        private readonly IGenerateDividendRepository generateDividendRepository;
        private readonly IEquityPlanRepository equityPlanRepository;
        private readonly IDividendTransactionHistoryRepository dividendTransactionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenerateDividendCommandHandler(IValidator<GenerateDividendDto> validator,
            IGenerateDividendRepository generateDividendRepository,
            IEquityPlanRepository equityPlanRepository,
            IDividendTransactionHistoryRepository dividendTransactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.generateDividendRepository = generateDividendRepository;
            this.equityPlanRepository = equityPlanRepository;
            this.dividendTransactionHistoryRepository = dividendTransactionHistoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(GenerateDividendCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);


            var equityPlan = await equityPlanRepository.Get(e => e.Id == request.Dto.EquityId)
                .Include(e => e.Offers.Where(c => c.Status == Domain.Enums.Offer.Vested.ToString()))
                .FirstOrDefaultAsync();

            if (equityPlan is not null)
            {
                if (equityPlan.Offers.Count == 0)
                {
                    var errors = new List<ValidationFailure>
                    {
                        new(nameof(request.Dto.EquityId), "Equity does not have vested offer")
                    };

                    throw new ValidationException(errors);
                }


                var generateDividend = new Domain.Models.GenerateDividend
                {
                    EquityId = equityPlan.Id,
                    EquityName = equityPlan.PlanName,
                    DividendPerShare = request.Dto.DividendPerShare,
                    TaxInPercentage = request.Dto.TaxInPercentage
                };
                var dividends = equityPlan.Offers.Select(n => new Domain.Models.Dividend
                {
                    ClaimedAmount = 0.0M,
                    DividendValue = request.Dto.DividendPerShare,
                    EmployeeEmailAddress = n.EquityHolderEmailAddress,
                    EmployeeName = n.OfferHolder,
                    EquityPlanName = equityPlan.PlanName,
                    EquityId = equityPlan.Id,
                    OfferValue = n.OfferValue,
                    Status = Domain.Enums.DividedStatus.Pending.ToString(),
                    TaxInPercentage = request.Dto.TaxInPercentage,
                    UnClaimedAmount = n.BalanceOfferValue > 0 ? CalculateUnClaimedAmount(n.BalanceOfferValue, request.Dto.DividendPerShare, request.Dto.TaxInPercentage) : 0.0M
                }).ToList();

                foreach (var dividend in dividends)
                {
                    dividend.Status = Domain.Enums.DividedStatus.Approved.ToString();

                    dividend.DividendTransactionHistories.Add(new Domain.Models.DividendTransactionHistory
                    {
                        Amount = dividend.UnClaimedAmount,
                        EmployeeEmailAddress = dividend.EmployeeEmailAddress,
                        EmployeeName = dividend.EmployeeName,
                        TransactionDate = DateTime.Now
                    });
                }

                generateDividend.Dividends = dividends;
                await generateDividendRepository.AddAsync(generateDividend);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            else
            {
                ApiException.ClientError("No vested offer found for the equity plan");
            }
        }

        decimal CalculateUnClaimedAmount(decimal offerValue, decimal dividendPerShare, decimal taxPercentage)
        {
            var tax = taxPercentage / 100.0M;
            var offer = offerValue * dividendPerShare;
            var taxAmount = offer * tax;

            var unclaimedAmount = offer - taxAmount;

            return unclaimedAmount;
        }


    }
}
