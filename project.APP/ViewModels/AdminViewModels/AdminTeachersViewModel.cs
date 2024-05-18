using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class AdminTeachersViewModel(
    ITeacherFacade teacherFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<TeacherListModel> Teachers { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Teachers = await teacherFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        Teachers = await teacherFacade.SearchTeacher(searchTerm);
    }

    [RelayCommand]
    async Task NewTeacher()
    {
        await Shell.Current.GoToAsync(nameof(AdminNewTeacherView));
    }
}

