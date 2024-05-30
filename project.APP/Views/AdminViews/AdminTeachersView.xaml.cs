using System.Diagnostics;
using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.AdminViews;

public partial class AdminTeachersView
{
	public AdminTeachersView(AdminTeachersViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
        {
            return;
        }

        var teacher = e.Item as TeacherListModel;
        if (teacher != null)
        {
            var route = $"{nameof(AdminNewTeacherView)}?teacherId={teacher.Id}";
            await Shell.Current.GoToAsync(route);
        }

        ((ListView)sender).SelectedItem = null;
    }
}
