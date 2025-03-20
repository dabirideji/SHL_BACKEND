namespace SHL.Application.DTO.Company.Request
{
    public class UpdatePoolDocumentDto
    {
        public Guid? OfferPoolId { get; set; }
        public string? DocumentTitle { get; set; }

        public string? DocumentType { get; set; }
        public string? DocumentBody { get; set; }
    }
}
