using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateInvitationDto
    {
        public Guid Id { get; set; }
        public InvitationType? InvitationType { get; set; }
        public InvitationStatus? InvitationStatus { get; set; }
    }
}
