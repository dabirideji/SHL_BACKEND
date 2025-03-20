using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateVestingDto
    {
        public VestingType? VestingType { get; set; }
        public string? VestingDetails { get; set; }
        public VestingRecursionType? RecursionType { get; set; }
        public int? RecursionInterval { get; set; }
        public double? RecursionAmount { get; set; }
        public double? InitialVestingAmount { get; set; }
        public int TotalDuration { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
