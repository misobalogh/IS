using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.AdminViews;

public partial class AdminSubjectsView
{
	public AdminSubjectsView(AdminSubjectsViewModel viewModel) : base(viewModel)
	{
		InitializeComponent();
	}
    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null)
        {
            return;
        }

        var subject = e.Item as SubjectListModel;
        if (subject != null)
        {
            var route = $"{nameof(AdminNewSubjectView)}?subjectId={subject.Id}";
            await Shell.Current.GoToAsync(route);
        }

        ((ListView)sender).SelectedItem = null;
    }
}
