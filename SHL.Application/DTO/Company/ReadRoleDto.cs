using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class ReadRoleDto
    {
        public Guid Id { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public RoleStatus? RoleStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
