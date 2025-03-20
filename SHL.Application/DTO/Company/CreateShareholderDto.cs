namespace SHL.Application.DTO.Company.Request
{
    public class CreateShareholderDto 
    {
        public string? CompanyCode { get; set; }
        public string? CompanyName { get; set; }
        public string? ShareholderNumber { get; set; }
        public string? ShareholderName { get; set; }
        public string? ShareholderAddress { get; set; }
        public string? ShareholderHolding { get; set; }
        public string? ShareholderEmailAddress { get; set; }
        public string? ShareholderPhoneNumber { get; set; }
    }

}
