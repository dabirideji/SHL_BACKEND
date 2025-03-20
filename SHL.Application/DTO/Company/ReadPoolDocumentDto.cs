namespace SHL.Application.DTO.Company.Request
{
    public class ReadPoolDocumentDto
    {
        public Guid Id { get; set; }
        public Guid? OfferPoolId { get; set; }
        public string? DocumentTitle { get; set; }

        public string? DocumentType { get; set; }
        public string? DocumentBody { get; set; }
        public string? DocumentFilePath { get;set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }













}
