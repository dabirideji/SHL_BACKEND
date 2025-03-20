using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactType
    {
        [EnumMember(Value = "EMPLOYEE")]
        EMPLOYEE,
        [EnumMember(Value = "HR")]
        HR,
        [EnumMember(Value = "ADMIN")]
        ADMIN,
        [EnumMember(Value = "STAKEHOLDER")]
        STAKEHOLDER,
        [EnumMember(Value = "EXECUTIVES")]
        EXECUTIVES
    }
}