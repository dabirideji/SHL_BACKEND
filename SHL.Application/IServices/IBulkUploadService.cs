using Microsoft.AspNetCore.Http;

namespace SHL.Application.Interfaces
{
    public interface IBulkUploadService{
        Task<object> UploadFile(Guid CompanyId,IFormFile file);
        Task ProcessExcelInBackground(string filePath, Guid CompanyId);
    }
}
