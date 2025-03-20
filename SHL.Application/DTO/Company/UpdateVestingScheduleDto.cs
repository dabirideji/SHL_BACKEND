using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateVestingScheduleDto
{

        public VestingRecursionType? VestingForPeriod { get; set; }
        public int? VestingForValue { get; set; }
        public VestingRecursionType? VestingEveryPeriod { get; set; }
        public int? VestingEveryValue { get; set; }
        public double? VestSpecificAmount { get; set; }
        public double? VestRelativePercentage { get; set; }
        public double? VestAmountInUnit { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public DateTime ExpiryDate { get; set; } 
}










}
