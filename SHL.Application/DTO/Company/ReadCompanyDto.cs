namespace SHL.Application.DTO.Company.Response
{
    public class ReadCompanyDto
    {
        public Guid Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public string? CompanyCurrencyCode { get; set; }
        public double CompanySharePriceValuation { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyDomainName { get; set; }
        public double? CompanyTotalShareAmount {get;set;}
        public double? CompanyAvailableShareAmount { get; set; }
        public double? CompanyVestableShareAmount { get; set; }
        public double? CompanyOptionableShareAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}