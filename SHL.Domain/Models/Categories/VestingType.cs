using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VestingType
    {
        [EnumMember(Value = "CUSTOM")]
        CUSTOM,
        [EnumMember(Value = "CLIFF_VESTING")]
        CLIFF_VESTING,
        [EnumMember(Value = "GRADED_VESTING")]
        GRADED_VESTING,
        [EnumMember(Value = "GRADUAL_VESTING")]
        GRADUAL_VESTING,
        [EnumMember(Value = "IMMEDIATE_VESTING")]
        IMMEDIATE_VESTING,
        [EnumMember(Value = "SPECIFICATION_VESTING")]
        SPECIFICATION_VESTING,
        [EnumMember(Value = "PERFORMANCE_VESTING")]
        PERFORMANCE_VESTING,
        [EnumMember(Value = "MILESTONE")]
        MILESTONE,
        [EnumMember(Value = "TIME_BASED_VESTING")]
        TIME_BASED_VESTING
    }
}