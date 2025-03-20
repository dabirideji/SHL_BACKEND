using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadOptionPoolApprovalDto
    {
        public Guid Id { get; set; }
        public Guid? OptionPoolOptionPoolId { get; set; }
        public string? OptionPoolApprovalApproverEmail { get; set; }
        public string? OptionPoolApprovalApprovalValue { get; set; }
        public DateTime? OptionPoolApprovalApprovalDate { get; set; }
        public OptionPoolApprovalStatus? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    }













}
