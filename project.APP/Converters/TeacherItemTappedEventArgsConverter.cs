using System.Globalization;
using CommunityToolkit.Maui.Converters;

namespace project.App.Converters;

public class TeacherItemTappedEventArgsConverter : BaseConverterOneWay<ItemTappedEventArgs, object>, IValueConverter
{
    public override object ConvertFrom(ItemTappedEventArgs value, CultureInfo? culture)
    {
        return value.Group;
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var eventArgs = value as ItemTappedEventArgs;
        return eventArgs.Item;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
