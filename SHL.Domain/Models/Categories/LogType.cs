using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LogType
    {
        [EnumMember(Value = "INFO")]
        INFO,
        [EnumMember(Value = "SUCCESS")]
        SUCCESS,
        [EnumMember(Value = "WARNING")]
        WARNING,
        [EnumMember(Value = "ERROR")]
        ERROR,
        [EnumMember(Value = "DEBUG")]
        DEBUG,
        [EnumMember(Value = "TRACE")]
        TRACE,
        [EnumMember(Value = "CRITICAL")]
        CRITICAL
    }
}