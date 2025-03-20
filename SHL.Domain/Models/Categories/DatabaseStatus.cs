using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DatabaseStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "MAINTENANCE")]
        MAINTENANCE,
        [EnumMember(Value = "DEPRECATED")]
        DEPRECATED,
        [EnumMember(Value = "FAULTY")]
        FAULTY,
        [EnumMember(Value = "UPGRADING")]
        UPGRADING
    }
}