using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class AdminSubjectsViewModel(
    ISubjectFacade subjectFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    private bool firstSearch = true;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        if (firstSearch && string.IsNullOrEmpty(searchTerm))
        {
            return;
        }
        firstSearch = false;
        Subjects = await subjectFacade.SearchSubject(searchTerm);
    }

    [RelayCommand]
    async Task NewSubject(string searchTerm)
    {
        await Shell.Current.GoToAsync(nameof(AdminNewSubjectView));
    }
}

