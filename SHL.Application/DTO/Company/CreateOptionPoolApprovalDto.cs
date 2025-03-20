using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class CreateOptionPoolApprovalDto
    {

        public Guid? OptionPoolOptionPoolId { get; set; }
        public string? OptionPoolApprovalApproverEmail { get; set; }
        public string? OptionPoolApprovalApprovalValue { get; set; }
        public OptionPoolApprovalStatus? Status { get; set; }
    }













}
