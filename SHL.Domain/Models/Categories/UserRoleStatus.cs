using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRoleStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "REVOKED")]
        REVOKED,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED
    }
}