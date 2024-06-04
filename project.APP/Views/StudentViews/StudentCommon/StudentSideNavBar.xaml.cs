using Microsoft.Maui.Controls;

namespace project.App.Views.StudentViews;
public partial class StudentSideNavBar : VerticalStackLayout
{
    public static readonly BindableProperty ActiveViewProperty =
        BindableProperty.Create(nameof(ActiveView), typeof(string), typeof(StudentSideNavBar), string.Empty);

    public string ActiveView
    {
        get => (string)GetValue(ActiveViewProperty);
        set => SetValue(ActiveViewProperty, value);
    }

    public StudentSideNavBar()
    {
        InitializeComponent();
    }
}
