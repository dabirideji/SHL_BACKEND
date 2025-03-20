namespace SHL.Application.DTO.Company.Request
{
    public class ReadUploadedDocumentDto
    {
        public Guid Id { get; set; }
        public string? DocumentFileType { get; set; }
        public string? DocumentFileName { get; set; }
        public string? DocumentFilePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
