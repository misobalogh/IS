using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentScheduleViewModel(IRegisteredActivitiesFacade registeredActivitiesFacade, IMessengerService messengerService) : StudentNavigationSideBar(messengerService)
{
    public IEnumerable<RegisteredActivitiesListModel> Activities { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await registeredActivitiesFacade.GetAsync();
    }

}

