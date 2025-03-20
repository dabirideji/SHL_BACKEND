using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StaffStatus
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE = 1,
        [EnumMember(Value = "ON_LEAVE")]
        ON_LEAVE,
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,
        [EnumMember(Value = "RESIGNED")]
        RESIGNED,
        [EnumMember(Value = "TERMINATED")]
        TERMINATED,
        [EnumMember(Value = "RETIRED")]
        RETIRED,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE
    }
}