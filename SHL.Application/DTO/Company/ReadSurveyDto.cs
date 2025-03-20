namespace SHL.Application.DTO.Company.Request
{
    public class ReadSurveyDto
    {
        public Guid Id {get;set;}
        public string? SurveyEmail { get; set; }
        public string? SurveyMessage { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}
