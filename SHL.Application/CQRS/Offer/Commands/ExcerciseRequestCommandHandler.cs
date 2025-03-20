using FluentValidation;
using MediatR;
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

namespace SHL.Application.CQRS.Offer.Commands
{
    public record ExcerciseRequestCommand(ExcerciseRequestDto Dto) : IRequest;
    class ExcerciseRequestCommandHandler : IRequestHandler<ExcerciseRequestCommand>
    {
        private readonly IValidator<ExcerciseRequestDto> validator;
        private readonly IAppSettingRepository appSettingRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IExcerciseRequestRepository excerciseRequestRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExcerciseRequestCommandHandler(IValidator<ExcerciseRequestDto> validator,
            IAppSettingRepository appSettingRepository,
            IUserIdentityService userIdentityService,
            IExcerciseRequestRepository excerciseRequestRepository,
            IOfferRepository offerRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.appSettingRepository = appSettingRepository;
            this.userIdentityService = userIdentityService;
            this.excerciseRequestRepository = excerciseRequestRepository;
            this.offerRepository = offerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(ExcerciseRequestCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var offer = await offerRepository.Get(u => u.Id == request.Dto.OfferId)
                .Include(e => e.EquityPlan)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var appSettings = await appSettingRepository
                .Get()
                .FirstOrDefaultAsync();

            await excerciseRequestRepository.AddAsync(new Domain.Models.ExcerciseRequest
            {
                Amount = request.Dto.Quantity,
                HolderName = $"{userIdentityService.FirstName} {userIdentityService.LastName}",
                ExercisePrice = offer!.ExcercisePrice,
                HolderEmailAddress = userIdentityService.EmailAddress,
                OfferId = offer.Id,
                PlanName = offer.EquityPlan!.PlanName,
                Status = Domain.Enums.ExcerciseRequest.Requested.ToString(),
                Tax = appSettings!.ExerciseRequestTaxValue,
                TotalCost = (request.Dto.Quantity * offer.ExcercisePrice) + appSettings.ExerciseRequestTaxValue
            });

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
