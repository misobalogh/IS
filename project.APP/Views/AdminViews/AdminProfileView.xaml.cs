using project.App.ViewModels;

namespace project.App.Views.AdminViews;

public partial class AdminProfileView
{
	public AdminProfileView(AdminProfileViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
	}
}
