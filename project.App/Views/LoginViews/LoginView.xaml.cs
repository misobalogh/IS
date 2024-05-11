using project.App.ViewModels;

namespace project.App.Views.LoginViews;

public partial class LoginView
{
	public LoginView(LoginViewModel viewModel) : base(viewModel)
	{
        InitializeComponent();
	}
}
