using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateCompanyDto
    {
        public Guid Id { get; set; }
        public string? CompanyAddress { get; set; }
        public CompanyInfrastructureStatus? CompanyInfrastructureStatus { get; set; }
        public CompanyInfrastructureType? CompanyInfrastructureType { get; set; }
        public string? CompanyInfrastructureConnectionString { get; set; }
        //SETTINGS
        public string? SettingName { get; set; }
        public List<string>? SettingDescription { get; set; }
    }
}