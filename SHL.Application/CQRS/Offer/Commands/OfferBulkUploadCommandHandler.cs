using ExcelDataReader;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SHL.Application.DTO.Offer;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;
using SHL.Application.ViewModels;
using SHL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SHL.Application.CQRS.Offer.Commands
{
    public record OfferBulkUploadCommand(OfferBulkUploadDto Dto) : IRequest<List<CreateOfferViewModel>>;
    class OfferBulkUploadCommandHandler : IRequestHandler<OfferBulkUploadCommand, List<CreateOfferViewModel>>
    {
        private readonly IValidator<OfferBulkUploadDto> validator;
        private readonly IEquityPlanRepository equityPlanRepository;
        private readonly IOfferRepository offerRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IExcelProcessor excelProcessor;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferUserChannel offerUserChannel;

        public OfferBulkUploadCommandHandler(IValidator<OfferBulkUploadDto> validator,
            IEquityPlanRepository equityPlanRepository,
            IOfferRepository offerRepository,
            IUserIdentityService userIdentityService,
            IExcelProcessor excelProcessor,
            IUnitOfWork unitOfWork,
            IOfferUserChannel offerUserChannel)
        {
            this.validator = validator;
            this.equityPlanRepository = equityPlanRepository;
            this.offerRepository = offerRepository;
            this.userIdentityService = userIdentityService;
            this.excelProcessor = excelProcessor;
            this.unitOfWork = unitOfWork;
            this.offerUserChannel = offerUserChannel;
        }
        public async Task<List<CreateOfferViewModel>> Handle(OfferBulkUploadCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var equityPlan = await equityPlanRepository.GetByIdAsync(request.Dto.EquityPlanId);

            var proposedOffers = excelProcessor.ReadOfferFromExcel(request.Dto.OfferFile.OpenReadStream());

            var existingOfferEmails = offerRepository.Get(o => o.EquityPlanId == request.Dto.EquityPlanId)
                .Select(s => s.EquityHolderEmailAddress)
                .ToList();

            //filter offers
            foreach (var offerEmail in existingOfferEmails)
            {
                var removeOffer = proposedOffers.FirstOrDefault(x => x.Email == offerEmail);
                if (removeOffer is not null)
                    proposedOffers.Remove(removeOffer);
            }

            var totalAllocatedUnits = proposedOffers.Sum(s => decimal.Parse(s.AllocatedUnits!));

            if (totalAllocatedUnits > equityPlan!.UnAllocated)
            {
                var errors = new List<ValidationFailure>
                {
                    new(nameof(request.Dto.EquityPlanId), "Total units from the excel file is more than the unallocated units")
                };
                throw new ValidationException(errors);
            }

            //var offers = proposedOffers.Select(o => new Domain.Models.Offer
            //{
            //    EquityPlanId = request.Dto.EquityPlanId,
            //    OfferHolder = o.Name!,
            //    EquityHolderEmailAddress = o.Email!,
            //    EquityHolderUniqueId = o.UniqueId,
            //    OfferValue = decimal.Parse(o.AllocatedUnits!),
            //    BalanceOfferValue = decimal.Parse(o.AllocatedUnits!),
            //    EstimatedOfferValue = CalculateOwnershipPercentage(equityPlan.TotalEquity, decimal.Parse(o.AllocatedUnits!)),
            //    VestStartDate = DateTime.Parse(o.DateIssued!),
            //    VestEndDate = DateTime.Parse(o.VestingDate!),
            //    VestingPeriod = CalculateVestingPeriod(DateTime.Parse(o.DateIssued!), DateTime.Parse(o.VestingDate!)),
            //    GrantDate = DateTime.Now,
            //    Status = Domain.Enums.Offer.Pending.ToString(),

            //}).ToList();

            //  await offerRepository.AddRangeAsync(offers);

            //equityPlan.Allocated = equityPlan.Allocated + totalAllocatedUnits;
            //equityPlan.UnAllocated = equityPlan.TotalEquity - equityPlan.Allocated;
            //equityPlan.PercentageAllocated = (equityPlan.Allocated / equityPlan.TotalEquity) * 100.0M;

            var offers = await offerRepository.CreateOffersAsync(proposedOffers, equityPlan,request.Dto.ExcercisePrice);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var viewModel = offers.Select(o => new CreateOfferViewModel
            {
                EmailAddress = o.EquityHolderEmailAddress,
                EquityPlanId = o.EquityPlanId,
                GrantDate = o.GrantDate,
                Name = o.OfferHolder,
                OfferId = o.Id,
                Ownership = o.OfferValue,
                Status = o.Status,
                VestingEndDate = o.VestEndDate,
                VestingStartDate = o.VestStartDate

            }).ToList();

            //Create users
            foreach (var item in proposedOffers)
            {
                await offerUserChannel.QueueItemAsync(new Models.StaffModel
                {
                    CompanyId = equityPlan.CompanyId,
                    EmailAddress = item.Email!,
                    StaffCode = item.UniqueId,
                    StaffDepartment = item.Division,
                    StaffGrade = item.Grade
                });
            }

            return viewModel;
        }

        //decimal CalculateOwnershipPercentage(decimal totalUnits, decimal allocatedOffer)
        //{
        //    var ownershipValue = (allocatedOffer / totalUnits) * 100.0M;
        //    return Math.Round(ownershipValue, 2);
        //}

        //double CalculateVestingPeriod(DateTime vestingStartDate, DateTime vestingEndDate)
        //{
        //    var days = (vestingEndDate - vestingStartDate).TotalDays;

        //    return days;
        //}
    }
}
