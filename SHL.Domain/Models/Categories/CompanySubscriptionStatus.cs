using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanySubscriptionStatus
    {
        [EnumMember(Value = "FREE")]
        FREE,
        [EnumMember(Value = "AMBASSADOR")]
        AMBASSADOR,
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "EXPIRED")]
        EXPIRED,
        [EnumMember(Value = "CANCELLED")]
        CANCELLED,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "TRIAL")]
        TRIAL
    }
}