using project.App.ViewModels;

namespace project.App.Views.StudentViews;

public partial class StudentProfileView
{
	public StudentProfileView(StudentProfileViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
	}
}
