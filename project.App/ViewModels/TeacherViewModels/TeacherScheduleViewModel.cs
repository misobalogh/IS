using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherScheduleViewModel(IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{    
    //TODO NOT IMPLEMENTED
}

