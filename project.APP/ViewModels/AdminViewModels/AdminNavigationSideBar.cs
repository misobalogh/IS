using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class AdminNavigationSideBar(IMessengerService messengerService, UserDataService userDataService) : ViewModelBase(messengerService)
{
    public string? loggedUser { get; set; }

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        loggedUser = userDataService.CurrentAdmin;
    }

    [RelayCommand]
    async Task GoToProfile()
    {
        await Shell.Current.GoToAsync(nameof(AdminProfileView));
    }

    [RelayCommand]
    async Task GoToTeacher()
    {
        await Shell.Current.GoToAsync(nameof(AdminTeachersView));
    }


    [RelayCommand]
    async Task GoToStudent()
    {
        await Shell.Current.GoToAsync(nameof(AdminStudentsView));
    }


    [RelayCommand]
    async Task GoToSubject()
    {
        await Shell.Current.GoToAsync(nameof(AdminSubjectsView));
    }


    [RelayCommand]
    async Task Logout()
    {
        if (Application.Current?.MainPage?.Navigation != null)
        {
            userDataService.ClearCurrentUser();
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

    }
}

