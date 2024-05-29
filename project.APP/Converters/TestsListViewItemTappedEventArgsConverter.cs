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

        var item = value.Item;
        if (item == null)
        {
            Debug.WriteLine("Item in ItemTappedEventArgs is null");
            return null;
        }

        Debug.WriteLine($"Item type: {item.GetType()}");

        if (item is ActivityListModel activityItem)
        {
            Debug.WriteLine($"Converted Item: {activityItem.SubjectName}, {activityItem.Name}, {activityItem.ActivityType}");
            return activityItem;
        }
        else
        {
            Debug.WriteLine($"Failed to cast Item to ActivityListModel. Actual type: {item.GetType()}");
            return null;
        }
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;
}
