using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DatabaseContextType
    {
        [EnumMember(Value = "TENNANT")]
        TENNANT,
        [EnumMember(Value = "MASTER")]
        MASTER,
    }
}