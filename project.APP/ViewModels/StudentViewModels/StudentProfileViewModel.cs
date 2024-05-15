using project.App.Services;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentProfileViewModel(
    ISubjectFacade subjectFacade, 
    IStudentFacade studentFacade, 
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{

    public StudentModel Students { get; set; } = null!;
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        if (loggedUser != null) { 
            Students = await studentFacade.GetAsync(loggedUser.Id);
        }
        Subjects = await subjectFacade.GetAsync();
    }
}
