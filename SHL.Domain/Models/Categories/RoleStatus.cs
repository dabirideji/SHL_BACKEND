using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "DEPRECATED")]
        DEPRECATED,
        [EnumMember(Value = "PENDING_APPROVAL")]
        PENDING_APPROVAL,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED
    }
}