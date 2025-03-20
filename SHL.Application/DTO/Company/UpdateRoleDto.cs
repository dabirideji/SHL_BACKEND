using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateRoleDto
    {
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public RoleStatus? RoleStatus { get; set; }
    }
}
