using CommunityToolkit.Maui.Converters;
using project.DAL.Enums;
using System.Globalization;

namespace project.App.Converters;

public class MarkToString : BaseConverterOneWay<Mark, string>
{
    public override string ConvertFrom(Mark value, CultureInfo? culture)
    {
        return value == Mark.None ? "-" : value.ToString();
    }

    public override string DefaultConvertReturnValue { get; set; } = "-";
}
