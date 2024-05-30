using System.Globalization;
using CommunityToolkit.Maui.Converters;
using project.BL.Models;

namespace project.App.Converters;

public class ItemTappedEventArgsConverter : BaseConverterOneWay<ItemTappedEventArgs, object>
{
    public override object ConvertFrom(ItemTappedEventArgs value, CultureInfo? culture)
    {
        return value.Item;
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;
}
