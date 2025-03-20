namespace SHL.Application.DTO.Company.Request
{
    public class CreateCompanyDto
    {
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyDomainName { get; set; }
        public double? CompanyAvailableShareAmount { get; set; }
        // public CompanyInfrastructureStatus? CompanyInfrastructureStatus { get; set; }
        // public CompanyInfrastructureType? CompanyInfrastructureType { get; set; }
        // public string? CompanyInfrastructureConnectionString { get; set; }

        //SETTINGS
        // public List<SettingValue>? SettingDescription { get; set; }
    }
}
