using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayoutAccountType
    {
        [EnumMember(Value = "SAVINGS")]
        SAVINGS,
        [EnumMember(Value = "CURRENT")]
        CURRENT,
        [EnumMember(Value = "CHECKING")]
        CHECKING,
        [EnumMember(Value = "BUSINESS")]
        BUSINESS,
        [EnumMember(Value = "CREDIT")]
        CREDIT
    }
}