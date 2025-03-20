namespace SHL.Application.DTO.Company.Request
{
    public class ReadEmploymentDetailDto
    {
        public Guid Id { get; set; }
        public Guid? EmployeeStaffId { get; set; }
        public string? EmployeeIdentificationNumber { get; set; }
        public string? EmployeeType { get; set; }
        public string? EmployeeCountry { get; set; }
        public string? EmployeeDesignation { get; set; }
        public string? EmployeeDepartment { get; set; }
        public string? EmployeeStartDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
