using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class StudentRegistrationViewModel(
    IActivityFacade activityFacade, 
    IMessengerService messengerService,
    StudentDataService studentDataService) : StudentNavigationSideBar(messengerService, studentDataService)
{

    public IEnumerable<ActivityListModel> Activities { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await activityFacade.GetAsync();
    }

    [RelayCommand]
    async Task Register(ActivityModel activity)
    {
        //TODO
    }
}

