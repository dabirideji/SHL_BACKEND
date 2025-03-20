namespace SHL.Application.DTO.Company.Request
{
    public class CreateUploadedDocumentDto
    {
        public string? DocumentFileType { get; set; }
        public string? DocumentFileName { get; set; }
        public string? DocumentFilePath { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile? file { get; set; }
    }
}
