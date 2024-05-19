using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class AdminNewSubjectViewModel(ISubjectFacade subjectFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public SubjectModel NewSubject { get; private set; } = SubjectModel.Empty;
    public List<Semester> Semesters { get; private set; } = Enum.GetValues(typeof(Semester)).Cast<Semester>().ToList();

    [RelayCommand]
    async Task CreateSubject()
    {
        if (string.IsNullOrEmpty(NewSubject.Name) ||
            string.IsNullOrEmpty(NewSubject.Tag))
        {
            NotifyUser("Please fill in all required fields: Name of the subject, tag.");
            return;
        }

        await subjectFacade.SaveAsync(NewSubject);
        NotifyUser("New subject successfully created");
        await Shell.Current.GoToAsync(nameof(AdminSubjectsView));
    }

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
