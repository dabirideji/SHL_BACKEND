using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CompanyInfrastructureStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "DISABLED")]
        DISABLED,
        [EnumMember(Value = "MAINTENANCE")]
        MAINTENANCE,
        [EnumMember(Value = "FAULTY")]
        FAULTY,
        [EnumMember(Value = "UPGRADING")]
        UPGRADING,
        [EnumMember(Value = "DECOMMISSIONED")]
        DECOMMISSIONED
    }
}