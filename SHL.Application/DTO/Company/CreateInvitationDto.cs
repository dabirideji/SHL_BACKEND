using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class CreateInvitationDto
    {
        public Guid InvitationSenderId { get; set; }
        public string? InvitationReceiverEmail { get; set; }
        public InvitationType? InvitationType { get; set; }
    }
}
