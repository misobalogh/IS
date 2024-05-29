using project.App.ViewModels;

namespace project.App.Views.StudentViews;

public partial class StudentRegistrationView
{
    private bool isRegistered = false;
    public StudentRegistrationView(StudentRegistrationViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }

    private void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            if (isRegistered)
            {
                button.Text = "Register";
                button.BackgroundColor = Color.FromRgb(171, 147, 227);
            }
            else
            {
                button.Text = "Registered";
                button.BackgroundColor = Color.FromRgb(255, 0, 0);
            }
            isRegistered = !isRegistered;
        }
    }
}
