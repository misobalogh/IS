using project.App.ViewModels;

namespace project.App.Views.StudentViews;

public partial class StudentSubjectsRegistrationView
{
    private bool isRegistered = false;
    //StudentSubjectsRegistrationViewModel vm;


    public StudentSubjectsRegistrationView(StudentSubjectsRegistrationViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
        //vm = viewModel;
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
