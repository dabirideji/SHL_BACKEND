using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WalletType
    {
        [EnumMember(Value = "PERSONAL")]
        PERSONAL,
        [EnumMember(Value = "BUSINESS")]
        BUSINESS,
        [EnumMember(Value = "PREPAID")]
        PREPAID,
        [EnumMember(Value = "VIRTUAL")]
        VIRTUAL,
        [EnumMember(Value = "CRYPTO")]
        CRYPTO
    }
}