using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class TeacherStudentsViewModel(
    IStudentFacade studentFacade,
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : TeacherNavigationSideBar(messengerService, userDataService)
{
    //TODO: pokud by se nekde mely zobrazovat studenti, ktere ucitel uci
    //public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;
    public IEnumerable<StudentListModel> Students { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        //EnrolledSubjects = await enrolledSubjectsFacade.GetAsync();
        Students = await studentFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        Students = await studentFacade.SearchStudent(searchTerm);
        //EnrolledSubjects = await enrolledSubjectsFacade.SearchSubject(searchTerm);
    }
}

