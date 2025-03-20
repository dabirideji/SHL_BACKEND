using MediatR;
using SHL.Application.DTO.EquityPlan;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using SHL.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHL.Application.IServices;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace SHL.Application.CQRS.EquityPlan.Commands
{
    public record CreateEquityPlanCommand(CreateEquityPlanDto Dto) : IRequest;
    class CreateEquityPlanCommandHandler : IRequestHandler<CreateEquityPlanCommand>
    {
        private readonly IEquityPlanRepository equityPlanRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserIdentityService userIdentityService;
        private readonly IValidator<CreateEquityPlanDto> validator;
        private readonly ICompanyRepository companyRepository;

        public CreateEquityPlanCommandHandler(IEquityPlanRepository equityPlanRepository,
            IUnitOfWork unitOfWork,
            IUserIdentityService userIdentityService,
            IValidator<CreateEquityPlanDto> validator,
            ICompanyRepository companyRepository)
        {
            this.equityPlanRepository = equityPlanRepository;
            this.unitOfWork = unitOfWork;
            this.userIdentityService = userIdentityService;
            this.validator = validator;
            this.companyRepository = companyRepository;
        }
        public async Task Handle(CreateEquityPlanCommand request, CancellationToken cancellationToken)
        {

            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var company = await companyRepository.GetByIdAsync(userIdentityService.CompanyId);

            var equityPlan = new Domain.Models.EquityPlan
            {
                CompanyId = userIdentityService.CompanyId,
                PlanName = request.Dto.PlanName,
                TotalEquity = request.Dto.TotalEquity,
                Allocated = 0.0M,
                CreatedAt = DateTime.UtcNow,
                PercentageAllocated = 0.0M,
                PercentageTotalEquity = Math.Round((request.Dto.TotalEquity / company!.CompanyTotalShareAmount) * 100.0M, 2),
                UnAllocated = request.Dto.TotalEquity,
                EquityType = (Domain.Enums.EquityType)Enum.Parse(typeof(Domain.Enums.EquityType), request.Dto.EquityType)
            };

            if (!string.IsNullOrEmpty(request.Dto.PlanRuleName))
            {
                equityPlan.ContractDocuments.Add(new ContractDocument
                {
                    DocumentContentUrl = request.Dto.PlanRuleContentUrl,
                    ContractDocumentType = Domain.Enums.ContractDocumentType.PlanRule,
                    DocumentName = request.Dto.PlanRuleName
                });
            }

            if (!string.IsNullOrEmpty(request.Dto.OfferLetterName))
            {
                equityPlan.ContractDocuments.Add(new ContractDocument
                {
                    DocumentContent = request.Dto.OfferLetterContent,
                    ContractDocumentType = Domain.Enums.ContractDocumentType.OfferLetter,
                    DocumentName = request.Dto.OfferLetterName
                });
            }

            var equityPlanEntity = await equityPlanRepository.AddAsync(equityPlan);
            await unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }

}
