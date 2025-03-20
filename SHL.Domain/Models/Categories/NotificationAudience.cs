using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationAudience
    {
        [EnumMember(Value = "ALL_USERS")]
        ALL_USERS,
        [EnumMember(Value = "SPECIFIC_USER")]
        SPECIFIC_USER,
        [EnumMember(Value = "ADMIN")]
        ADMIN,
        [EnumMember(Value = "STAFF")]
        STAFF,
        [EnumMember(Value = "GUEST")]
        GUEST,
        [EnumMember(Value = "CUSTOM_SEGMENT")]
        CUSTOM_SEGMENT
    }
}