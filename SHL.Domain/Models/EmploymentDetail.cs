using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class EmploymentDetail : BaseEntity
    {
        [ForeignKey("EmployeeStaffData")]
        public Guid? EmployeeStaffId { get; set; }
        public Staff? EmployeeStaffData { get; set; }
        public string? EmployeeIdentificationNumber { get; set; }
        public string? EmployeeType { get; set; }
        public string? EmployeeCountry { get; set; }
        public string? EmployeeDesignation { get; set; }
        public string? EmployeeDepartment { get; set; }
        public string? EmployeeStartDate { get; set; }
    }
}