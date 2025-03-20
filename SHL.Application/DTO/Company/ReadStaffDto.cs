using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadStaffDto
    {
        public string EmailAddress { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string? CompanyName { get; set; }
        public string? CompanyLogo { get; set; }
        public double SharePrice { get; set; }

        public StaffStatus? StaffStatus { get; set; }
        
    }
}
