using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class Invitation : BaseEntity
    {
        
        [ForeignKey("InvitationSender")]
        public Guid InvitationSenderId { get; set; }
       // public User? InvitationSender { get; set; }
        public string? InvitationReceiverEmail { get; set; }
        public InvitationType? InvitationType { get; set; }
        public InvitationStatus? InvitationStatus { get; set; }=Categories.InvitationStatus.PENDING;
    }
}