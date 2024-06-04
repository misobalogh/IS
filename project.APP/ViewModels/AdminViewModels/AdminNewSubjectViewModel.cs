using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class AdminNewSubjectViewModel(ISubjectFacade subjectFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public string? SubjectId { get; set; }
    public SubjectModel NewSubject { get; private set; } = SubjectModel.Empty;
    public List<Semester> Semesters { get; private set; } = Enum.GetValues(typeof(Semester)).Cast<Semester>().ToList();

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (string.IsNullOrEmpty(SubjectId))
        {
            return;
        }

        NewSubject = await subjectFacade.GetAsync(Guid.Parse(SubjectId)) ?? SubjectModel.Empty;
    }



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

    [RelayCommand]
    async Task DeleteSubject()
    {
        if (string.IsNullOrEmpty(SubjectId))
        {
            NotifyUser("Subject not found");
            return;
        }

        await subjectFacade.DeleteAsync(Guid.Parse(SubjectId));
        NotifyUser("Subject successfully deleted");
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
