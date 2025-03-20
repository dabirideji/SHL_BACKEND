using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayoutAccountStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "VERIFIED")]
        VERIFIED,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "DELETED")]
        DELETED
    }
}