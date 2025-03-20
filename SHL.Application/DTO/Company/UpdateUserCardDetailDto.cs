using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateUserCardDetailDto
    {
        public string? BillingAddress { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public Status Status { get; set; }
    }
}
