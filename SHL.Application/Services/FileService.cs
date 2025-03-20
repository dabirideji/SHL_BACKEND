using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InventoryManagement.Application.Services.Customer
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void CreateDirectory(params string[] directoryParts)
        {
            if (directoryParts == null || directoryParts.Length == 0)
            {
                throw new ArgumentException("At least one directory part must be provided.", nameof(directoryParts));
            }

            var path = Path.Combine(_environment.WebRootPath, Path.Combine(directoryParts));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public async Task<string> UploadFileAsync(string subFolder, IFormFile file)
        {
            if (file.Length <= 0)
            {
                return "Invalid File || Something went wrong";
            }

            var filePath = Path.Combine(_environment.WebRootPath, "Uploads", subFolder);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var fullPath = Path.Combine(filePath, file.FileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("Uploads", subFolder, file.FileName); 
        }
    }
}