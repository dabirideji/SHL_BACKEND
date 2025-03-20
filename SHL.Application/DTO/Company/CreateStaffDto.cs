namespace SHL.Application.DTO.Company.Request
{
    public class CreateStaffDto
    {
        public Guid StaffCompanyId { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? StaffDepartment {get;set;}
         public string? StaffGrade {get;set;}
        public string? LastName { get; set; }
        public bool? IsAdmin {get;set;}=false;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }













}
