using MediatR;
using SHL.Application.DTO.File;
using SHL.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.File.Commands
{
    public record UploadFileCommand(UploadDto Dto) :IRequest<string>;
    class UploadFileCommandHandler(IAzureBlobStorageService azureBlobStorageService) : IRequestHandler<UploadFileCommand, string>
    {
        public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var url = await azureBlobStorageService.UploadFileAsync(request.Dto.File.OpenReadStream(), request.Dto.File.ContentType, request.Dto.File.FileName, request.Dto.FolderName, cancellationToken);
            return url;
        }
    }
}
