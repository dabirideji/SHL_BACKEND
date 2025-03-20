using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.IServices
{
    public interface IAzureBlobStorageService
    {
        ValueTask<string> UploadFileAsync(Stream file, string contentType, string fileName, string folderName, CancellationToken cancellationToken = default);
        Task<(byte[] File, string ContentType)> DownloadBlobAsync(string containerName, string fileName, CancellationToken cancellationToken);
        ValueTask<(byte[] File, string ContentType)> DownloadFileAsync(string fileName, CancellationToken cancellationToken = default);
    }
}
