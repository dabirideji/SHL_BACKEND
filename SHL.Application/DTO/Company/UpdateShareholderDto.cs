namespace SHL.Application.DTO.Company.Request
{
    public class UpdateShareholderDto 
    {
        public Guid Id{get;set;}
        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public string? ShareholderNumber { get; set; }
        public string? ShareholderName { get; set; }
        public string? ShareholderAddress { get; set; }
        public string? ShareholderEmailAddress { get; set; }
        public string? ShareholderPhoneNumber { get; set; }
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
    }

}
