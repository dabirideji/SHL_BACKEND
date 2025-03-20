
namespace SHL.Domain.Models
{
    public class UploadedDocument : BaseEntity
    {
        public string? DocumentFileType { get; set; }
        public string? DocumentFileName { get; set; }
        public string? DocumentFilePath { get; set; }
    }
}