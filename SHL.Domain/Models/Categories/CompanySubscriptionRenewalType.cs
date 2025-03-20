using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanySubscriptionRenewalType
    {
        [EnumMember(Value = "MANUAL")]
        MANUAL,
        [EnumMember(Value = "ONE_OFF")]
        ONE_OFF,
        [EnumMember(Value = "AUTOMATIC")]
        AUTOMATIC,
        [EnumMember(Value = "ON_DEMAND")]
        ON_DEMAND,
        [EnumMember(Value = "NOT_RENEWABLE")]
        NOT_RENEWABLE
    }
}