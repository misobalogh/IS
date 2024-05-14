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

    public List<string> Schedule { get; set; } = ["IZU"];

    public string TestTODO { get; set; } = "ICS\nD0207";

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await registeredActivitiesFacade.GetAsync();
        CreateScheduleList();
    }

    public void CreateScheduleList()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                var activities = Activities.Where(a => (int)a.Start.DayOfWeek == i+1 && a.Start.Hour == 7 + j);
                if (activities.Any()) {
                    Schedule.Add(activities.First().ActivityName + "\n" + activities.First().Room.ToString());
                } else
                {
                    Schedule.Add("Volno");
                }
            }
        }
    }

}

