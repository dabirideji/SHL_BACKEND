using Microsoft.AspNetCore.Http;

namespace SHL.Application.DTO.Company.Request
{
    public class CreateOptionHolderSignatureDto
    {
        public Guid? OptionHolderId { get; set; }
        public DateTime SignatureDate { get; set; }
        public IFormFile SignatureFile { get; set; }
    }

}
