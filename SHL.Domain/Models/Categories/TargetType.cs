using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TargetType
    {
        [EnumMember(Value = "INDIVIDUAL")]
        INDIVIDUAL,             // Targeting specific individual(s)
        [EnumMember(Value = "GROUP")]
        GROUP                   // Targeting a group of staff based on conditions
    }
}