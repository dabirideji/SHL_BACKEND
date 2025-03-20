using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OptionPoolStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,
        [EnumMember(Value = "CLOSED")]
        CLOSED,
        [EnumMember(Value = "DEPRECATED")]
        DEPRECATED
    }
}