using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadVestingScheduleDto
{
    public Guid Id{get;set;}
        public Guid GrantId { get; set; }
        public VestingType? VestingType { get; set; }
        public VestingRecursionType? VestingForPeriod { get; set; }
        public int? VestingForValue { get; set; }
        public VestingRecursionType? VestingEveryPeriod { get; set; }
        public int? VestingEveryValue { get; set; }
        public string? VestingDetails{get;set;}
        public double? VestSpecificAmount { get; set; }
        public double? VestRelativePercentage { get; set; }
        public double? VestAmountInUnit { get; set; }
        public VestingAvailability? VestingAvailability { get; set; }
        public VestingStatus VestingStatus{get;set;}
        public Status Status { get; set; } 
        public DateTime? StartDate { get; set;} 
        public DateTime? EndDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
}










}
