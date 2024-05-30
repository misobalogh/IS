using System.Diagnostics;
using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.StudentViews;

public partial class StudentTestsView   
{

    StudentTestsViewModel vm;

    public StudentTestsView(StudentTestsViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
        vm = viewModel;
	}

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        var activity = button!.CommandParameter as ActivityListModel;

        if (button != null)
        {
            if (await vm.IsRegistered(activity))
            {
                //await vm.Unregister(activity!.Id);
                button.Text = "Register";
                button.BackgroundColor = Color.FromRgb(171, 147, 227);
            }
            else
            {
                await vm.Register(activity: activity);
                button.Text = "Unregister";
                button.BackgroundColor = Color.FromRgb(255, 0, 0);
            }
        }
    }

    private async void OnLoad(object sender, EventArgs e)
    {
        var button = sender as Button;

        var activity = button!.CommandParameter as ActivityListModel;

        if (button != null)
        {
            if (await vm.IsRegistered(activity))
            {
                button.Text = "Unregister";
                button.BackgroundColor = Color.FromRgb(255, 0, 0);
            }
            else
            {
                button.Text = "Register";
                button.BackgroundColor = Color.FromRgb(171, 147, 227);
            }
        }
    }
}
