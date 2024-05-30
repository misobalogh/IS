using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.AdminViews;

public partial class AdminStudentsView
{
	public AdminStudentsView(AdminStudentsViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
        {
            return;
        }

        var student = e.Item as StudentListModel;
        if (student != null)
        {
            var route = $"{nameof(AdminNewStudentView)}?studentId={student.Id}";
            await Shell.Current.GoToAsync(route);
        }

        ((ListView)sender).SelectedItem = null;
    }
}
