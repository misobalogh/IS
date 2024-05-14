using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentSubjectsViewModel(
    ISubjectFacade subjectFacade, 
    IMessengerService messengerService,
    StudentDataService studentDataService) : StudentNavigationSideBar(messengerService, studentDataService)
{    
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }
}

