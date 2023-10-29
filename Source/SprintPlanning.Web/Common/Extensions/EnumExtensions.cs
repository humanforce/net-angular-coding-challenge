using System.ComponentModel;

namespace SprintPlanning.Common.Extensions;
public static class EnumExtensions
{
    public static string Description(this Enum value)
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attribute = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attribute.Length > 0 ? ((DescriptionAttribute)attribute[0]).Description : value.ToString();
    }
}
