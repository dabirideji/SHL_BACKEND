using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        [EnumMember(Value = "ADMIN")]
        ADMIN,
        [EnumMember(Value = "USER")]
        USER,
        [EnumMember(Value = "GUEST")]
        GUEST,
        [EnumMember(Value = "MODERATOR")]
        MODERATOR,
        [EnumMember(Value = "SUPER_ADMIN")]
        SUPER_ADMIN
    }
}