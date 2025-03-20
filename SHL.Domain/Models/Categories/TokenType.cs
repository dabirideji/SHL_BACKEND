using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SHL.Domain.Models.Categories
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TokenType
    {
        [EnumMember(Value = "BEARER")]
        BEARER,
        [EnumMember(Value = "API_KEY")]
        API_KEY,
        [EnumMember(Value = "REFRESH")]
        REFRESH,
        [EnumMember(Value = "ACCESS")]
        ACCESS,
        [EnumMember(Value = "JWT")]
        JWT,
        [EnumMember(Value = "OAUTH")]
        OAUTH,
        [EnumMember(Value = "PASSWORD_RESET")]
        PASSWORD_RESET,
        [EnumMember(Value = "EMAIL_VERIFICATION")]
        EMAIL_VERIFICATION,
        [EnumMember(Value = "ACCOUNT_ACTIVATION")]
        ACCOUNT_ACTIVATION,
        [EnumMember(Value = "PASSWORD_CHANGE")]
        PASSWORD_CHANGE
    }
}