using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class StudentProfileViewModel(
    ISubjectFacade subjectFacade, 
    IStudentFacade studentFacade, 
    IMessengerService messengerService,
    StudentDataService studentDataService) : StudentNavigationSideBar(messengerService, studentDataService)
{

    public StudentModel? loggedUser { get; set; }
    public Guid Id { get; set; } = Guid.Parse("789a3e3a-0d52-4cc6-b5b2-6e5819594380");
    public StudentModel Students { get; set; } = null!;
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        //TODO: získat Guid podle přihlášení
        Students = await studentFacade.GetAsync(Id);
        Subjects = await subjectFacade.GetAsync();
        loggedUser = studentDataService.CurrentStudent;
    }
}
