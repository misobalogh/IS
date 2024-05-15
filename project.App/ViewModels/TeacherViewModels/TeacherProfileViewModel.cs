using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherProfileViewModel(IMessengerService messengerService, UserDataService userDataService, ITeacherFacade teacherFacade) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public TeacherModel? Teacher { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (loggedUser != null)
        {
            Teacher = await teacherFacade.GetAsync(loggedUser.Id);
        }
    }
}
