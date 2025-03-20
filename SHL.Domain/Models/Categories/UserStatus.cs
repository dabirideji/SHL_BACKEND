using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "PENDING_VERIFICATION")]
        PENDING_VERIFICATION,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "LOCKED")]
        LOCKED,
        [EnumMember(Value = "DELETED")]
        DELETED
    }
}