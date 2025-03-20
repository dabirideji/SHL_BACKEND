using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvitationStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "SENT")]
        SENT,
        [EnumMember(Value = "ACCEPTED")]
        ACCEPTED,
        [EnumMember(Value = "REJECTED")]
        REJECTED,
        [EnumMember(Value = "EXPIRED")]
        EXPIRED,
        [EnumMember(Value = "CANCELLED")]
        CANCELLED
    }
}