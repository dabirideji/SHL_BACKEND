using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadGrantDto
    {

        public Guid Id { get; set; }
        public Guid? GrantOptionPoolId { get; set; }
        public double GrantStrikePrice { get; set; }
        public double GrantExercisePrice { get; set; }
        public double GrantShareAmountTotal { get; set; }
        public double GrantShareAmountAvailable { get; set; }
        public double? GrantShareAmountVestable { get; set; }
        public double GrantShareAmountVested { get; set; }
        public double GrantShareAmountUnvested { get; set; }
        public Status GrantStatus { get; set; }
        // public ICollection<VestingSchedule>? GrantVestingSchedules { get; set; }
        // public ICollection<OptionHolder>? TargetOptionHolders { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
