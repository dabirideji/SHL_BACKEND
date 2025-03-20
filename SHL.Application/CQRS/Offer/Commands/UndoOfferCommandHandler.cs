using MediatR;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record UndoOfferCommand(UndoOfferDto Dto) :IRequest;
    class UndoOfferCommandHandler : IRequestHandler<UndoOfferCommand>
    {
        private readonly IOfferRepository offerRepository;
        private readonly IUnitOfWork unitOfWork;

        public UndoOfferCommandHandler(IOfferRepository offerRepository,
            IUnitOfWork unitOfWork)
        {
            this.offerRepository = offerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(UndoOfferCommand request, CancellationToken cancellationToken)
        {
            await offerRepository.UndoOffersAsync(request.Dto.OfferIds);          
        }
    }
}
