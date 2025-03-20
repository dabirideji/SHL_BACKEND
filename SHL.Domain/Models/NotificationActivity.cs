using System.ComponentModel.DataAnnotations.Schema;

namespace SHL.Domain.Models
{
    public class NotificationActivity : BaseEntity
    {
        [ForeignKey("NotificationActivityNotfication")]
        public Guid NotificationActivityNotificationId { get; set; }
        public Notification? NotificationActivityNotification { get; set; }
        public Guid NotificationActivityNotificationUserId { get; set; }
        public NotificationActivityReadStatus? NotificationActivityReadStatus { get; set; }
        public DateTime NotificationActivityReadAt { get; set; } = DateTime.MinValue;
    }
}