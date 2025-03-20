using FluentValidation;
using MediatR;
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
    public record SignOfferCommand(SignOfferDto Dto) : IRequest;
    class SignOfferCommandHandler : IRequestHandler<SignOfferCommand>
    {
        private readonly IValidator<SignOfferDto> validator;
        private readonly IOfferRepository offerRepository;
        private readonly IUserIdentityService userIdentityService;
        private readonly IAzureBlobStorageService azureBlobStorageService;
        private readonly ITransactionHistoryRepository transactionHistoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public SignOfferCommandHandler(IValidator<SignOfferDto> validator,
            IOfferRepository offerRepository,
            IUserIdentityService userIdentityService,
            IAzureBlobStorageService azureBlobStorageService,
            ITransactionHistoryRepository transactionHistoryRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.offerRepository = offerRepository;
            this.userIdentityService = userIdentityService;
            this.azureBlobStorageService = azureBlobStorageService;
            this.transactionHistoryRepository = transactionHistoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(SignOfferCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var fileName = $"{userIdentityService.SubjectId}_{request.Dto.Signature.FileName}";
            var url =await azureBlobStorageService.UploadFileAsync(request.Dto.Signature.OpenReadStream(), request.Dto.Signature.ContentType, fileName, "signature", cancellationToken);

            var result = await offerRepository.SignOfferAsync(request.Dto.OfferId, url);
            if (result > 0 )
            {
                //save to transaction table
                await transactionHistoryRepository.SaveOfferAsTransactionHistoryAsync(new List<Guid> { request.Dto.OfferId}, "granted", userIdentityService.CompanyId, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
            //convert offer to PDF, upload to Azure and save to offer table

        }
    }
}
