using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DatabaseType
    {
        [EnumMember(Value = "SQL_DATABASE")]
        SQL_DATABASE,
        [EnumMember(Value = "SQLITE")]
        SQLITE,
        [EnumMember(Value = "SQL_SERVER")]
        SQL_SERVER,
        [EnumMember(Value = "POSTGRESQL")]
        POSTGRESQL,
        [EnumMember(Value = "MYSQL")]
        MYSQL,
        [EnumMember(Value = "ORACLE")]
        ORACLE,
        [EnumMember(Value = "MONGODB")]
        MONGODB,
        [EnumMember(Value = "COSMOSDB")]
        COSMOSDB,
        [EnumMember(Value = "REDIS")]
        REDIS
    }
}