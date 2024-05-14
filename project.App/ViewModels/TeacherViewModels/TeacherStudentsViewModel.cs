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
    IMessengerService messengerService) 
    : TeacherNavigationSideBar(messengerService)
{


    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
    }
    // TODO load students, go student by student, load attending classes and chcek if contains current class??
}

