namespace SHL.Application.DTO.Company.Request
{
    public class UpdateEmploymentDetailDto
    {
        public Guid? EmployeeStaffId { get; set; }
        public string? EmployeeIdentificationNumber { get; set; }
        public string? EmployeeType { get; set; }
        public string? EmployeeCountry { get; set; }
        public string? EmployeeDesignation { get; set; }
        public string? EmployeeDepartment { get; set; }
        public string? EmployeeStartDate { get; set; }
    }
}
