namespace SHL.Domain.Models
{
    public class ExcerciseSetting : BaseEntity
    {
        public string? ExcerciseSettingName { get; set; }
        public string? ExcerciseSettingDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public string? ExerciseCriteria { get; set; }
    }
}