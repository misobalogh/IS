using project.App.ViewModels;

namespace project.App.Views.StudentViews;

public partial class StudentRegistrationView
{
	public StudentRegistrationView(StudentRegistrationViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}
}
