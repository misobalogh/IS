using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;
using CommunityToolkit.Mvvm.Messaging;
using project.App.Views.TeacherViews;

namespace project.App.ViewModels;

public partial class TeacherClassificationViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    ISubjectFacade subjectFacade,
    IMessengerService messengerService, UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public EnrolledSubjectsModel? EnrolledSubjects { get; private set; }
    public IEnumerable<SubjectListModel> Subjects { get; set; } = new List<SubjectListModel>();
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (loggedUser == null) return;

        var allSubjects = await subjectFacade.GetAsync();
        var teacherSubjectIds = loggedUser.TeachingSubjects.Select(ts => ts.SubjectId).ToList();
        Subjects = allSubjects.Where(subject => teacherSubjectIds.Contains(subject.Id)).ToList();
        EnrolledSubjects = await enrolledSubjectsFacade.GetAsync(Guid.Parse("371a5d4a-c60d-4e45-b3a1-db2bca96b24e"));
    }

    [RelayCommand]
    async Task ShowSubjectDetails(EnrolledSubjectsModel subject)
    {
        if (subject == null) return;
        var route = $"{nameof(StudentClassificationSubjectDetailView)}?subjectId={subject.SubjectId}";
        await Shell.Current.GoToAsync(route);
    }
}

