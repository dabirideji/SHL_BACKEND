using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class CompanySetting : BaseEntity
    {
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        public List<SettingValue>? SettingsValues { get; set; }
        public Status IsActive { get; set; } = Status.ACTIVE;
    }
}