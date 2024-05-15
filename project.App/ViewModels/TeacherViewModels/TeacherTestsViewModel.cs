using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherTestsViewModel(
    IActivityFacade activityFacade, 
    IMessengerService messengerService, 
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{    
    public IEnumerable<ActivityListModel> Activities { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await activityFacade.GetAsync();
        //TODO filter activities that are only TESTS
    }
}

