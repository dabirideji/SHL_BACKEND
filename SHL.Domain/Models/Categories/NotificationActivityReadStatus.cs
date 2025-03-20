using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationActivityReadStatus
    {
        [EnumMember(Value = "READ")]
        READ,
        [EnumMember(Value = "UNREAD")]
        UNREAD,
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "ARCHIVED")]
        ARCHIVED,
        [EnumMember(Value = "DISABLED")]
        DISABLED
    }
}