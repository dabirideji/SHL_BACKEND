namespace SHL.Domain.Models
{
    public class Notification : BaseEntity
    {
        public string? NotificationTitle { get; set; }
        public NotificationType? NotificationType { get; set; }
        public NotificationAudience? NotificationAudience { get; set; }
        public string? NotificationMessage { get; set; }
        public string? NotificationBody { get; set; }
        public NotificationStatus? NotificationStatus { get; set; }
    }
}