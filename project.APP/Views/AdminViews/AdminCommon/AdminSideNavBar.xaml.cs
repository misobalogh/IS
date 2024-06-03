using Microsoft.Maui.Controls;

namespace project.App.Views.AdminViews;
public partial class AdminSideNavBar : VerticalStackLayout
{
    public static readonly BindableProperty ActiveViewProperty =
        BindableProperty.Create(nameof(ActiveView), typeof(string), typeof(AdminSideNavBar), string.Empty);

    public string ActiveView
    {
        get => (string)GetValue(ActiveViewProperty);
        set => SetValue(ActiveViewProperty, value);
    }

    public AdminSideNavBar()
    {
        InitializeComponent();
    }
}
