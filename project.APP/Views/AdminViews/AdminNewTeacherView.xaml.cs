using project.App.ViewModels;
using AdminNewTeacherViewModel = project.App.ViewModels.AdminViewModels.AdminNewTeacherViewModel;

namespace project.App.Views.AdminViews;

public partial class AdminNewTeacherView
{
	public AdminNewTeacherView(AdminNewTeacherViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}
}
