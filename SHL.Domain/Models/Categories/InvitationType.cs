using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvitationType
    {
        [EnumMember(Value = "EMAIL")]
        EMAIL,
        [EnumMember(Value = "SMS")]
        SMS,
        [EnumMember(Value = "PUSH_NOTIFICATION")]
        PUSH_NOTIFICATION,
        [EnumMember(Value = "IN_APP")]
        IN_APP,
        [EnumMember(Value = "PHONE_CALL")]
        PHONE_CALL
    }
}