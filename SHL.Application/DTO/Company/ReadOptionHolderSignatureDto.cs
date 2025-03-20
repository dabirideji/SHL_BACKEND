using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadOptionHolderSignatureDto
    {
        public Guid Id { get; set; }
        public Guid? OptionHolderId { get; set; }
        public DateTime SignatureDate { get; set; }
        public string? SignatureFilePath { get; set; }
        public Status Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
