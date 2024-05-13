using project.App.Services;
using project.App.ViewModels;
using project.BL.Facades;

namespace project.App.Views.StudentViews;

public partial class StudentProfileView
{
	public StudentProfileView(StudentProfileViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
    }
}
