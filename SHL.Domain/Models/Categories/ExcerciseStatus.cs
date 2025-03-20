using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExcerciseStatus
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "COMPLETED")]
        COMPLETED,
        [EnumMember(Value = "CANCELLED")]
        CANCELLED,
        [EnumMember(Value = "FAILED")]
        FAILED,
        [EnumMember(Value = "IN_PROGRESS")]
        IN_PROGRESS
    }
}