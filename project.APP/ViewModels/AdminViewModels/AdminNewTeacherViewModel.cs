using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Mappers;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels.AdminViewModels;

[QueryProperty(nameof(TeacherId), "teacherId")]
public partial class AdminNewTeacherViewModel(
    ITeacherFacade teacherFacade, 
    ISubjectFacade subjectFacade,
    ITeachingSubjectsFacade teachingSubjectsFacade,
    TeachingSubjectsModelMapper teachingSubjectsModelMapper,
    IMessengerService messengerService, 
    UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public string? TeacherId { get; set; }
    public TeacherModel NewTeacher { get; private set; } = TeacherModel.Empty;
    public TeachingSubjectsModel? TeachingSubjectNew { get; private set; }
    public ObservableCollection<SubjectListModel> Subjects { get; set; } = new ObservableCollection<SubjectListModel>();
    public ObservableCollection<SubjectListModel> AssignedSubjects { get; set; } = new ObservableCollection<SubjectListModel>();
    public SubjectListModel? SelectedSubject { get; set; }
    public List<TitleBefore> TitlesBefore { get; private set; } = Enum.GetValues(typeof(TitleBefore)).Cast<TitleBefore>().ToList();
    public List<TitleAfter> TitlesAfter { get; private set; } = Enum.GetValues(typeof(TitleAfter)).Cast<TitleAfter>().ToList();
    
    protected override async Task LoadDataAsync()
    {
        if (string.IsNullOrEmpty(TeacherId))
        {
            return;
        }

        await base.LoadDataAsync();
        NewTeacher = await teacherFacade.GetAsync(Guid.Parse(TeacherId)) ?? TeacherModel.Empty;
        foreach (var subject in await subjectFacade.GetAsync())
        {
            Subjects.Add(subject);
        }

        foreach (var teachingSubject in NewTeacher.TeachingSubjects)
        {
            var subject = Subjects.FirstOrDefault(s => s.Id == teachingSubject.SubjectId);
            if (subject != null)
            {
                AssignedSubjects.Add(subject);
            }
        }
    }

    [RelayCommand]
    async Task AddSubjectToTeacher()
    {
        if (SelectedSubject == null || AssignedSubjects.Contains(SelectedSubject)) {
            return;
        }

        TeachingSubjectNew = new()
        {
            Id = Guid.NewGuid(),
            SubjectId = SelectedSubject.Id,
            Year = DateTime.Now,
        };


        teachingSubjectsModelMapper.MapToExistingDetailModel(TeachingSubjectNew, SelectedSubject);

        await teachingSubjectsFacade.SaveAsync(TeachingSubjectNew, NewTeacher.Id);
        NewTeacher.TeachingSubjects.Add(teachingSubjectsModelMapper.MapToListModel(TeachingSubjectNew));

        AssignedSubjects.Add(SelectedSubject);

    }

    [RelayCommand]
    async Task RemoveSubjectFromTeacher(SubjectListModel subject)
    {
        AssignedSubjects.Remove(subject);
        var allSubjects = await teachingSubjectsFacade.GetAsync();
        var subjectToDelete = allSubjects.Where(ts => ts.Id == subject.Id /*&& NewTeacher.Id == ts.TeacherId*/);
        //await teachingSubjectsFacade.DeleteAsync(subjectToDelete);

    }

    [RelayCommand]
    async Task CreateTeacher()
    {
        if (string.IsNullOrEmpty(NewTeacher.Email) ||
            string.IsNullOrEmpty(NewTeacher.FirstName) ||
            string.IsNullOrEmpty(NewTeacher.LastName))
        {
            NotifyUser("Please fill in all required fields: First Name, Last Name, and Email.");
            return;
        }

        if (!NewTeacher.Email.Contains('@'))
        {
            NotifyUser("Invalid email");
            return;
        }

        // Check if email is unique
        bool emailExists = await teacherFacade.EmailExistsAsync(NewTeacher.Email);
        if (emailExists && string.IsNullOrEmpty(TeacherId))
        {
            NotifyUser("Email already exists.");
            return;
        }

        await teacherFacade.SaveAsync(NewTeacher);
        NotifyUser("Changes Saved");
        await Shell.Current.GoToAsync(nameof(AdminTeachersView));
    }

    [RelayCommand]
    async Task DeleteTeacher()
    {
        if (string.IsNullOrEmpty(TeacherId))
        {
            NotifyUser("Teacher not found");
            return;
        }

        await teacherFacade.DeleteAsync(Guid.Parse(TeacherId));
        NotifyUser("Teacher successfully deleted");
        await Shell.Current.GoToAsync(nameof(AdminTeachersView));
    }

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
