using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExcerciseType
    {
        [EnumMember(Value = "STANDARD")]
        STANDARD,
        [EnumMember(Value = "CASHLESS")]
        CASHLESS,
        [EnumMember(Value = "CASH_WITH_OPTION")]
        CASH_WITH_OPTION,
        [EnumMember(Value = "AUTO_LIQUIDATE")]
        AUTO_LIQUIDATE
    }
}