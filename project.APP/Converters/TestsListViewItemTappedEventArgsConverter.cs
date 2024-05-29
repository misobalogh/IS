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

        if (value.Group == null)
        {
            Debug.WriteLine("Group in ItemTappedEventArgs is null");
            return null;
        }

        var item = value.Group as ActivityListModel;
        if (item == null)
        {
            Debug.WriteLine($"Failed to cast Group to ActivityListModel. Actual type: {value.Group.GetType()}");
        }
        else
        {
            Debug.WriteLine($"Converted Group: {item.SubjectName}, {item.Name}, {item.ActivityType}");
        }

        return item;
    }

    public override object DefaultConvertReturnValue { get; set; } = null!;
}
