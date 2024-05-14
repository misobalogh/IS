using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;

namespace project.App.ViewModels;

public partial class TeacherProfileViewModel(IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{
    
}
