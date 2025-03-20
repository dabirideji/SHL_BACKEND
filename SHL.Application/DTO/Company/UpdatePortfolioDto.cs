using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdatePortfolioDto

    {
        public Guid? OptionId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? EmployeeEmail { get; set; }
        public string? CompanyName { get; set; }
        public double? TotalShareAmount { get; set; }
        public double? TotalShareValuation { get; set; }
        public double? DilutedOwnershipPercentage { get; set; }
        public double? TotalShareUnits { get; set; }
        public Status? Status { get; set; }
    }













}
