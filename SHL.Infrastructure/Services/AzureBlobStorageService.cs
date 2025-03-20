using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SHL.Application.AppSettings;
using SHL.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Infrastructure.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly ILogger<AzureBlobStorageService> logger;
        private readonly AzureBlobStorageSetting azureBlobStorageConfig;
        const string baseFolder = "equityplan";
        public AzureBlobStorageService(ILogger<AzureBlobStorageService> logger,
            IOptionsSnapshot<AzureBlobStorageSetting> azureBlobStorageConfig)
        {
            this.logger = logger;
            this.azureBlobStorageConfig = azureBlobStorageConfig.Value;
        }

        BlobContainerClient ConnectToBlobAccount()
        {
            var blobContainerClient = new BlobContainerClient(new Uri(azureBlobStorageConfig.ContainerUrl),
                 new Azure.AzureSasCredential(azureBlobStorageConfig.SasToken));
            return blobContainerClient;
        }

        public async ValueTask<string> UploadFileAsync(Stream file, string contentType, string fileName, string folderName, CancellationToken cancellationToken = default)
        {
            fileName = $"{folderName}/{fileName}";
            BlobContainerClient blobContainerClient = ConnectToBlobAccount();

            var binaryData = new BinaryData(await BinaryData.FromStreamAsync(file));

            var blob = blobContainerClient.GetBlobClient(fileName);

            await blob.UploadAsync(binaryData, new BlobUploadOptions { HttpHeaders = new BlobHttpHeaders { ContentType = contentType } }, default);
            return blob.Uri.AbsoluteUri;

        }

        public async ValueTask<(byte[] File, string ContentType)> DownloadFileAsync(string fileName, CancellationToken cancellationToken = default)
        {
            BlobContainerClient blobContainerClient = ConnectToBlobAccount();
            var blob = blobContainerClient.GetBlobClient(fileName);
            var file = await blob.DownloadContentAsync(cancellationToken);

            return (file.Value.Content.ToArray(), file.Value.Details.ContentType);
        }

        public async Task<(byte[] File, string ContentType)> DownloadBlobAsync(string containerName, string fileName, CancellationToken cancellationToken)
        {
            var blobContainerClient = new BlobContainerClient(azureBlobStorageConfig.ConnectionString, containerName);

            // Get reference to the blob (profile image)
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            var result = await blobClient.DownloadContentAsync(cancellationToken);

            return (result.Value.Content.ToArray(), result.Value.Details.ContentType);

        }
    }
}
