using Microsoft.AspNetCore.Http;

public interface IFileService
{
    void CreateDirectory(params string[] directoryParts);
    Task<string> UploadFileAsync(string subFolder, IFormFile file);
}
