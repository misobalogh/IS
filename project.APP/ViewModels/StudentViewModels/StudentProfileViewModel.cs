using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class StudentProfileViewModel(ISubjectFacade subjectFacade, IStudentFacade studentFacade, IMessengerService messengerService) : ViewModelBase(messengerService)
{
    public Guid Id { get; set; } = Guid.Parse("789a3e3a-0d52-4cc6-b5b2-6e5819594380");
    public StudentModel Students { get; set; } = null!;
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        //TODO: získat Guid podle přihlášení
        Students = await studentFacade.GetAsync(Id);
        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    async Task GoToStudentProfile()
    {
        await Shell.Current.GoToAsync(nameof(StudentProfileView));
    }
    [RelayCommand]
    async Task GoToSchedule()
    {
        await Shell.Current.GoToAsync(nameof(StudentScheduleView));
    }
    [RelayCommand]
    async Task GoToClassification()
    {
        await Shell.Current.GoToAsync(nameof(StudentClassificationView));
    }
    [RelayCommand]
    async Task GoToSubjects()
    {
        await Shell.Current.GoToAsync(nameof(StudentSubjectsView));
    }
    [RelayCommand]
    async Task GoToTests()
    {
        await Shell.Current.GoToAsync(nameof(StudentTestsView));
    }
    [RelayCommand]
    async Task GoToRegistration()
    {
        await Shell.Current.GoToAsync(nameof(StudentRegistrationView));
    }
}
