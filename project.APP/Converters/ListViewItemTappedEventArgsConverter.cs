using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace project.App.Converters;

public class ItemTappedEventArgsConverter : BaseConverterOneWay<ItemTappedEventArgs, object>
{
    public override object ConvertFrom(ItemTappedEventArgs value, CultureInfo? culture)
    {
        return value.Group;
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;
}
