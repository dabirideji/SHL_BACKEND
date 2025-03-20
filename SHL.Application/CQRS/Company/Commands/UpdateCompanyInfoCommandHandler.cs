using FluentValidation;
using MediatR;
using SHL.Application.DTO.Company;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.Company.Commands
{
    public record UpdateCompanyInfoCommand(UpdateCompanyInfoDto Dto) : IRequest<Domain.Models.Company?>;
    class UpdateCompanyInfoCommandHandler : IRequestHandler<UpdateCompanyInfoCommand, Domain.Models.Company?>
    {
        private readonly IValidator<UpdateCompanyInfoDto> validator;
        private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAzureBlobStorageService azureBlobStorageService;
        private readonly IUserIdentityService userIdentityService;

        public UpdateCompanyInfoCommandHandler(IValidator<UpdateCompanyInfoDto> validator,
            ICompanyRepository companyRepository,
            IUnitOfWork unitOfWork,
            IAzureBlobStorageService azureBlobStorageService,
            IUserIdentityService userIdentityService)
        {
            this.validator = validator;
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
            this.azureBlobStorageService = azureBlobStorageService;
            this.userIdentityService = userIdentityService;
        }
        public async Task<Domain.Models.Company?> Handle(UpdateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var company = await companyRepository.GetByIdAsync(userIdentityService.CompanyId);
            if (company is not null)
            {
                if (request.Dto.Logo is not null)
                {
                    var logoUrl = await azureBlobStorageService.UploadFileAsync(request.Dto.Logo.OpenReadStream(), request.Dto.Logo.ContentType, request.Dto.Logo.FileName, "companylogo", cancellationToken);
                    company.LogoUrl = logoUrl;
                }

                company.CompanyTotalShareAmount = request.Dto.TotalShares;
                company.CompanySharePriceValuation = request.Dto.SharePrice;
                company.CompanyEmailAddress = request.Dto.CompanyEmailAddress;
                company.CompanyName = request.Dto.CompanyName;

                await companyRepository.UpdateAsync(company);

                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return company;
        }
    }
}
