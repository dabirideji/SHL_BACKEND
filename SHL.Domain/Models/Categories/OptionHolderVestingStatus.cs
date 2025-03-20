using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OptionHolderVestingStatus
    {
        [EnumMember(Value = "AWAITING_VESTING")]
        AWAITING_VESTING,
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "CANCELLED")]
        CANCELLED,
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