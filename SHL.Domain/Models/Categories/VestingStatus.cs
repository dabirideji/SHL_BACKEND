using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VestingStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "PENDING_APPROVAL")]
        PENDING_APPROVAL,
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "VESTING")]
        VESTING, 
        [EnumMember(Value = "VESTED")]
        VESTED,
        [EnumMember(Value = "UNVESTED")]
        UNVESTED,
        [EnumMember(Value = "REVOKED")]
        REVOKED,
        [EnumMember(Value = "CANCELLED")]
        CANCELLED
    }
}