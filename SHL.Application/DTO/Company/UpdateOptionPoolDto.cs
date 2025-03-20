using System.ComponentModel.DataAnnotations;
using SHL.Domain.Models.Categories;

namespace SHL.Application.DTO.Company.Request
{
    public class UpdateOptionPoolDto
    {
        [Required]
        public string? OptionPoolName { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "OptionPoolTotalShares must be at least 1.")]
        public double OptionPoolTotalShares { get; set; }
     }
}
