using System.Runtime.Serialization;

namespace RubiksCube.Domain.Enums;

public enum Color
{
    [EnumMember(Value = "White")]
    White,

    [EnumMember(Value = "Green")]
    Green,

    [EnumMember(Value = "Red")]
    Red,

    [EnumMember(Value = "Blue")]
    Blue,

    [EnumMember(Value = "Orange")]
    Orange,

    [EnumMember(Value = "Yellow")]
    Yellow
}
