namespace SHL.Application.DTO.Company.Request
{
    public class CreatePortfolioDto

    {
        public string? EmployeeEmail { get; set; }
        public Guid? OptionId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string? CompanyName { get; set; }
        public double? TotalShareAmount { get; set; }
        public double? TotalShareValuation { get; set; }
        public double? DilutedOwnershipPercentage { get; set; }
        public double? TotalShareUnits { get; set; }
    }













}
