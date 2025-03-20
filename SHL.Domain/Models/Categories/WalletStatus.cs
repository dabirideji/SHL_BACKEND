using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WalletStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,
        [EnumMember(Value = "LOCKED")]
        LOCKED,
        [EnumMember(Value = "CLOSED")]
        CLOSED
    }
}