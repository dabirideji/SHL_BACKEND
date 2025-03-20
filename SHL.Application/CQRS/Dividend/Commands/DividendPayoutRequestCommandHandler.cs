using FluentValidation;
using MediatR;
using SHL.Application.DTO.Dividend;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Dividend.Commands
{
    public record DividendPayoutRequestCommand(DividendPayoutRequestDto Dto) : IRequest;
    class DividendPayoutRequestCommandHandler : IRequestHandler<DividendPayoutRequestCommand>
    {
        private readonly IValidator<DividendPayoutRequestDto> validator;
        private readonly IDividendPayoutRequestRepository dividendPayoutRequestRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IDividendRepository dividendRepository;
        private readonly IUnitOfWork unitOfWork;

        public DividendPayoutRequestCommandHandler(IValidator<DividendPayoutRequestDto> validator,
            IDividendPayoutRequestRepository dividendPayoutRequestRepository,
            IUserIdentityService userIdentityService,
            IDividendRepository dividendRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.dividendPayoutRequestRepository = dividendPayoutRequestRepository;
            this.userIdentityService = userIdentityService;
            this.dividendRepository = dividendRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(DividendPayoutRequestCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var dividend = dividendRepository.Get(u => u.Id == request.Dto.DividendId && u.EmployeeEmailAddress == userIdentityService.EmailAddress)
                .AsNoTracking()
                .FirstOrDefault();

            await dividendPayoutRequestRepository.AddAsync(new Domain.Models.DividendPayoutRequest
            {
                DividendId = dividend!.Id,
                Amount = request.Dto.Amount,
                EmployeeEmailAddress = userIdentityService.EmailAddress,
                EmployeeName = dividend.EmployeeName,
                Status = Domain.Enums.PayoutRequest.Pending.ToString()
            });

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
