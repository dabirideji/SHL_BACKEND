using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Application.ViewModels;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record CreateOfferCommand(CreateOfferDto Dto) : IRequest;
    class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand>
    {
        private readonly IValidator<CreateOfferDto> validator;
        private readonly IEquityPlanRepository equityPlanRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferEmailChannel offerEmailChannel;
        private readonly ICompanyUserRepository companyUserRepository;

        public CreateOfferCommandHandler(IValidator<CreateOfferDto> validator,
            IEquityPlanRepository equityPlanRepository,
            IOfferRepository offerRepository,
            IUnitOfWork unitOfWork,
            IOfferEmailChannel offerEmailChannel,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.equityPlanRepository = equityPlanRepository;
            this.offerRepository = offerRepository;
            this.unitOfWork = unitOfWork;
            this.offerEmailChannel = offerEmailChannel;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var equityPlan = await equityPlanRepository.GetByIdAsync(request.Dto.EquityPlanId);
            var users = await companyUserRepository.Get(u => request.Dto.EmailAddresses.Contains(u.Email!))
                .ToListAsync();

            var proposedOffers = request.Dto.EmailAddresses.Select(e => new Models.OfferExcelModel
            {
                AllocatedUnits = request.Dto.OfferValue.ToString(),
                DateIssued = request.Dto.VestStartDate.ToString(),
                Email = e,
                Name = GetName(users, e),
                VestingDate = request.Dto.VestEndDate.ToString(),
                Division = "",
                Grade = "",
                UniqueId = ""

            }).ToList();

            var offers = await offerRepository.CreateOffersAsync(proposedOffers, equityPlan, request.Dto.ExcercisePrice);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var item in proposedOffers)
            {
                await offerEmailChannel.QueueItemAsync(new Models.EmailModel
                {
                    EmailAddress = item.Email!,
                    Message = $"Dear user,\n\nYou have been allocated an equity offer of {request.Dto.OfferValue:N2}. Kindly login to your portal to claim your offer.",
                    Subject = "Offer Allocation"
                });
            }
        }


        string GetName(List<CompanyUser> users, string emailAddress)
        {
            var user = users.FirstOrDefault(u => u.NormalizedEmail == emailAddress.ToUpperInvariant());

            return user == null ? "" : $"{user.FirstName} {user.LastName}";
        }
    }
}
