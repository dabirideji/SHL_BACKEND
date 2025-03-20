using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadContactDto
    {
        public Guid Id { get; set; }
        public ContactType? ContactType { get; set; }
        public string? ContactName { get; set; }
        public double? ContactHeldInTrust { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactEmployeeIdentificationNumber { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string? ContactAddressUnit { get; set; }
        public string? ContactAddressStreet { get; set; }
        public string? ContactAddressCity { get; set; }
        public string? ContactAddressState { get; set; }
        public string? ContactAddressPostalCode { get; set; }
        public string? ContactAddressCountry { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }













}
