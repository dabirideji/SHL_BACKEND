using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Domain.Models;

namespace InventoryManagement.Application.Services.Customer
{
    public class UploadedDocumentService : GenericService<UploadedDocument, CreateUploadedDocumentDto, UpdateUploadedDocumentDto, ReadUploadedDocumentDto>, IUploadedDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        public UploadedDocumentService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public override async Task<UploadedDocument> AddAsync(CreateUploadedDocumentDto dto)
        {
            if(dto.file!=null)
            {
                _fileService.CreateDirectory(dto.DocumentFileName);
                var path=await _fileService.UploadFileAsync(Guid.NewGuid().ToString(),dto.file);
                dto.DocumentFilePath=path;
            }
         
            return await base.AddAsync(dto);
        }
    }















}
