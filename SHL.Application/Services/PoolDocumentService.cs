using AutoMapper;
using SHL.Application.CustomExceptions;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class PoolDocumentService : GenericService<PoolDocument, CreatePoolDocumentDto, UpdatePoolDocumentDto, ReadPoolDocumentDto>, IPoolDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IUploadedDocumentService _uploadedDocumentService;
        private readonly IMapper _mapper;
        public PoolDocumentService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService, IUploadedDocumentService uploadedDocumentService) : base(unitOfWork, mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _uploadedDocumentService = uploadedDocumentService;
        }

        public override async Task<PoolDocument> AddAsync(CreatePoolDocumentDto createDto)
        {
            return new PoolDocument();
            //var _optionPoolRepo = _unitOfWork.GetRepository<OptionPool>();
            //var validOptionPool = await _optionPoolRepo.GetByIdAsync((Guid)createDto.OfferPoolId);
            //if (validOptionPool == null)
            //{
            //    ApiException.ClientError("INVALID OPTION POOL ID");
            //}
            //var file = createDto.PoolDocumentFile;
            //CreateUploadedDocumentDto createDocumentDto = new CreateUploadedDocumentDto
            //{
            //    file = file,
            //    DocumentFileName = file.FileName,
            //    DocumentFileType = createDto.DocumentType
            //};
            //var uploadedDocumentResponse = await _uploadedDocumentService.AddAsync(createDocumentDto);
            //createDto.DocumentFilePath = uploadedDocumentResponse.DocumentFilePath;
            //return await base.AddAsync(createDto);
        }
    }
}
