using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherSubjectsViewModel(ISubjectFacade subjectFacade, IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{    
    //TODO NOT IMPLEMENTED
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }
}

