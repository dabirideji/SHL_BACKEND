using System.Runtime.Serialization;

namespace SHL.Domain.Models.Categories
{
    public enum VestingRecursionType
    {
        [EnumMember(Value = "DAYS")]
        DAYS,
        [EnumMember(Value = "MONTHS")]
        MONTHS,
        [EnumMember(Value = "YEARS")]
        YEARS
    }
}