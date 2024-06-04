using Microsoft.Maui.Controls;

namespace project.App.Views.TeacherViews;
public partial class TeacherSideNavBar : VerticalStackLayout
{
    public static readonly BindableProperty ActiveViewProperty =
        BindableProperty.Create(nameof(ActiveView), typeof(string), typeof(TeacherSideNavBar), string.Empty);

    public string ActiveView
    {
        get => (string)GetValue(ActiveViewProperty);
        set => SetValue(ActiveViewProperty, value);
    }

    public TeacherSideNavBar()
    {
        InitializeComponent();
    }
}
