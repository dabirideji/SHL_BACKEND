using System.ComponentModel.DataAnnotations;

namespace SHL.Application.DTO.Company.Request
{
    public class SendTokenDto
    {
        [Required]
        [EmailAddress] public string EmailAddress { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
