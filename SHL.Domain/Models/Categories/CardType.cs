using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CardType
    {
        [EnumMember(Value = "MASTERCARD")]
        MASTERCARD,
        [EnumMember(Value = "VERVE")]
        VERVE,
        [EnumMember(Value = "VISA")]
        VISA
    }
}