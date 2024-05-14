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

    //public List<string> mylist { get; set; } = new List<string>(new string[] { "IZU", "IDS" });

    public Dictionary<string, string> Schedule { get; set; } = [];

    public string TestTODO { get; set; } = "ICS\nD0207";

    protected override async Task LoadDataAsync()
    {
        Schedule.Add("2024-05-14T08:00:00", "IZU");
        await base.LoadDataAsync();
        Activities = await registeredActivitiesFacade.GetAsync();
    }

}

