using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.TeacherViews;

public partial class TeacherSubjectsDetailView
{
	public TeacherSubjectsDetailView(TeacherSubjectsDetailViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}


    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Group == null)
        {
            return;
        }

        var activity = e.Group as ActivityListModel;
        if (activity != null)
        {
            var route = $"{nameof(TeacherNewActivityView)}?activityId={activity.Id}";
            await Shell.Current.GoToAsync(route);
        }

        ((ListView)sender).SelectedItem = null;
    }
}
