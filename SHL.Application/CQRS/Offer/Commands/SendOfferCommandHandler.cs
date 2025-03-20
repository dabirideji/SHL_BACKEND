using FluentValidation;
using MediatR;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using SHL.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record SendOfferCommand(SendOfferDto Dto) : IRequest;
    class SendOfferCommandHandler : IRequestHandler<SendOfferCommand>
    {
        private readonly IValidator<SendOfferDto> validator;
        private readonly IOfferRepository offerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMailService mailService;
        private readonly ITransactionHistoryRepository transactionHistoryRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IOfferEmailChannel offerEmailChannel;

        public SendOfferCommandHandler(IValidator<SendOfferDto> validator,
            IOfferRepository offerRepository,
            IUnitOfWork unitOfWork,
            IMailService mailService,
            ITransactionHistoryRepository transactionHistoryRepository,
            IUserIdentityService userIdentityService,
            IOfferEmailChannel offerEmailChannel)
        {
            this.validator = validator;
            this.offerRepository = offerRepository;
            this.unitOfWork = unitOfWork;
            this.mailService = mailService;
            this.transactionHistoryRepository = transactionHistoryRepository;
            this.userIdentityService = userIdentityService;
            this.offerEmailChannel = offerEmailChannel;
        }
        public async Task Handle(SendOfferCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var status = request.Dto.MarkAsPortfolio ? Domain.Enums.Offer.Vesting.ToString() : Domain.Enums.Offer.AwaitingVesting.ToString();

            await offerRepository.SendOfferAsync(request.Dto.OfferIds, status);
            var result =await unitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0 && request.Dto.MarkAsPortfolio)
            {
                //save to transaction table
                await transactionHistoryRepository.SaveOfferAsTransactionHistoryAsync(request.Dto.OfferIds, "granted", userIdentityService.CompanyId, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            //email offer letter
            if (result > 0)
            {
                var holders = offerRepository.Get(o => request.Dto.OfferIds.Contains(o.Id))
                    .Select(s => new EmailModel
                    {
                        EmailAddress = s.EquityHolderEmailAddress,
                        Message = $"Dear {s.OfferHolder},\n\n You have received an offer of {s.OfferValue} which is currently {status}.",
                        Subject = "Offer Received"
                    }).ToList();

                foreach (var holder in holders)
                {
                    await offerEmailChannel.QueueItemAsync(holder);
                }
            }

        }
    }
}
