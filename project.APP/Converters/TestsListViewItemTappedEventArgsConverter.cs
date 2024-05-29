using System.Diagnostics;
using System.Globalization;
using CommunityToolkit.Maui.Converters;
using project.BL.Models;

namespace project.App.Converters;

public class TestsListViewItemTappedEventArgsConverter : BaseConverterOneWay<ItemTappedEventArgs, object>
{
    public override ActivityListModel ConvertFrom(ItemTappedEventArgs value, CultureInfo? culture)
    {
        if (value == null)
        {
            Debug.WriteLine("ItemTappedEventArgs is null");
            return null;
        }

        var item = value.Item as ActivityListModel;
        if (item == null)
        {
            Debug.WriteLine($"Failed to cast Item to ActivityListModel. Actual type: {value.Item.GetType()}");
        }
        else
        {
            Debug.WriteLine($"Converted Item: {item.SubjectName}, {item.Name}, {item.ActivityType}");
        }

        return item;
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;
}
