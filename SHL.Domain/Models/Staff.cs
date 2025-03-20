using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class Staff : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public string CompanyUserId { get; set; } = default!;
        public string? StaffCode { get; set; }
        public string? StaffDepartment { get; set; }
        public string? StaffGrade { get; set; }
        public string? CscsNumber { get; set; }
        public string? ChnNumber { get; set; }
        public string? Designation { get; set; }
        public Company? Company { get; set; }
        public CompanyUser? CompanyUser { get; set; }
        public StaffStatus? StaffStatus { get; set; } = Categories.StaffStatus.ACTIVE;

        public virtual StaffBank Bank { get; set; } = new StaffBank();
    }
}
