using CommunityToolkit.Maui.Converters;
using project.DAL.Enums;
using System.Globalization;

namespace project.App.Converters;

public class Points : BaseConverterOneWay<int?, string>
{
    public override string ConvertFrom(int? value, CultureInfo? culture)
    {
        if (value == null)
        {
            return "-";
        }
        return value.ToString()!;
    }   
    public override string DefaultConvertReturnValue { get; set; } = "-";
}
