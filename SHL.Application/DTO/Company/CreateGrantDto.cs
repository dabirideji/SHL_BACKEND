using System.ComponentModel.DataAnnotations;
using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class CreateGrantDto
    {
        public Guid? GrantOptionPoolId { get; set; }
        public double GrantShareAmountTotal { get; set; }
        public double GrantStrikePrice { get; set; }
        public double GrantExercisePrice =>GrantStrikePrice;
        public double GrantShareAmountAvailable => GrantShareAmountTotal;
        public List<string>? GrantTargetEmails { get; set; }
        public List<CreateVestingScheduleDto>? Vestings { get; set; }

    }
}
