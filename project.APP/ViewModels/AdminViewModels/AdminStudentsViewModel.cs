using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class AdminStudentsViewModel(
    IStudentFacade studentFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<StudentListModel> Students { get; set; } = null!;
    private bool firstSearch = true;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = await studentFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        if (firstSearch && string.IsNullOrEmpty(searchTerm))
        {
            return;
        }
        firstSearch = false;
        Students = await studentFacade.SearchStudent(searchTerm);
    }

    [RelayCommand]
    async Task NewStudent(string searchTerm)
    {
        await Shell.Current.GoToAsync(nameof(AdminNewStudentView));
    }
}

