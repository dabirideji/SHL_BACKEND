using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadInvitationDto
    {
        public Guid Id { get; set; }
        public Guid InvitationSenderId { get; set; }
        public string? InvitationReceiverEmail { get; set; }
        public InvitationType? InvitationType { get; set; }
        public InvitationStatus? InvitationStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
