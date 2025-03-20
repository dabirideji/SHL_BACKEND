using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OptionPoolApprovalStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "APPROVED")]
        APPROVED,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "WITHDRAWN")]
        WITHDRAWN
    }
}