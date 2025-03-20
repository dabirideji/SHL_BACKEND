using System.ComponentModel.DataAnnotations.Schema;
namespace SHL.Domain.Models
{
    public class OptionPoolApproval : BaseEntity
    {
        [ForeignKey("OptionPoolOptionPool")]
        public Guid? OptionPoolOptionPoolId { get; set; }
        public OptionPool? OptionPoolOptionPool { get; set; }
        public string? OptionPoolApprovalApproverEmail { get; set; }
        public string? OptionPoolApprovalApprovalValue { get; set; }
        public DateTime? OptionPoolApprovalApprovalDate { get; set; } = DateTime.Now;
        public OptionPoolApprovalStatus? Status { get; set; }
    }
}