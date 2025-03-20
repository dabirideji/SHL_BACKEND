using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateGrantDto
    {
        public Guid? GrantOptionPoolId { get; set; }
        public double GrantShareAmountAvailable { get; set; }

        public double GrantStrikePrice { get; set; }
        public double GrantExercisePrice { get; set; }
        public List<string>? GrantTargetEmails { get; set; }
    }
}
