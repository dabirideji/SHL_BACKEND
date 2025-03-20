using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateOptionHolderDto
    {
        public Guid OptionHolderGrantId { get; set; }
        public string? OptionHolderEmailAddress { get; set; }
        public Guid OptionHolderStaffId { get; set; }
        public double OptionHolderAmount { get; set; }
        public OptionHolderStatus OptionHolderStatus { get; set; }
    }
}
