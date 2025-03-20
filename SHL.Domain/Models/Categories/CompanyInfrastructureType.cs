using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanyInfrastructureType
    {
        [EnumMember(Value = "BASIC")]
        BASIC,
        [EnumMember(Value = "CORPORATE")]
        CORPORATE,
        [EnumMember(Value = "INDUSTRIAL")]
        INDUSTRIAL,
        [EnumMember(Value = "ENTERPRISE")]
        ENTERPRISE,
        [EnumMember(Value = "SMALL_BUSINESS")]
        SMALL_BUSINESS,
        [EnumMember(Value = "STARTUP")]
        STARTUP
    }
}