using Microsoft.AspNetCore.Http;

namespace SHL.Application.DTO.Company.Request
{
    public class CreatePoolDocumentDto
    {
        public Guid? OfferPoolId { get; set; }
        public string? DocumentTitle { get; set; }

        public string? DocumentType { get; set; }
        public string? DocumentBody { get; set; }
        public IFormFile? PoolDocumentFile {get;set;}
               public string? DocumentFilePath { get;set;}

    }













}
