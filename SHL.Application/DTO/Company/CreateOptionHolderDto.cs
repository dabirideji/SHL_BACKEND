namespace SHL.Application.DTO.Company.Request;
public class CreateOptionHolderDto
{
    public Guid OptionHolderGrantId { get; set; }
    public string? OptionHolderEmailAddress { get; set; }
    public Guid OptionHolderStaffId { get; set; }
    public double OptionHolderAmount { get; set; }
}