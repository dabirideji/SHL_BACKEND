using SHL.Domain.Models;
using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadOptionHolderDto
    {
        public Guid Id { get; set; }
        public Guid OptionHolderGrantId { get; set; }
        public string? OptionHolderEmailAddress { get; set; }
        public Guid OptionHolderStaffId { get; set; }
        public double OptionHolderAmount { get; set; }
        public OptionHolderStatus OptionHolderStatus { get; set; }
        public OptionHolderVestingStatus OptionHolderVestingStatus { get; set; }
        public ICollection<VestingActivation>? VestingActvations { get; set; }
        public bool OptionHoldingIsSent { get; set; }
        public bool OptionHoldingIsSigned { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
