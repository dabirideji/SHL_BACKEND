using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VestingAvailability
    {
        [EnumMember(Value = "AVAILABLE")]
        AVAILABLE,
        [EnumMember(Value = "NOT_AVAILABLE")]
        NOT_AVAILABLE,
        [EnumMember(Value = "CONDITIONAL")]
        CONDITIONAL,
        [EnumMember(Value = "RESTRICTED")]
        RESTRICTED
    }
}