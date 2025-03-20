using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OptionHolderStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "SIGNED")]
        SIGNED,
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "APPROVED")]
        APPROVED,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "VESTING")]
        VESTING,
        [EnumMember(Value = "VESTED")]
        VESTED,
        [EnumMember(Value = "PAUSED")]
        PAUSED,
    }
}