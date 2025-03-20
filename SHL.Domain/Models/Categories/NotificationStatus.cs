using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "FAILED")]
        FAILED,
        [EnumMember(Value = "ARCHIVED")]
        ARCHIVED,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "DELETED")]
        DELETED
    }
}