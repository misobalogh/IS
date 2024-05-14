using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherScheduleViewModel(IRegisteredActivitiesFacade registeredActivitiesFacade,
    IMessengerService messengerService) : TeacherNavigationSideBar(messengerService)
{
    public IEnumerable<RegisteredActivitiesListModel> Activities { get; set; } = null!;

    private List<string> schedule = null!;
    public List<string> Schedule
    {
        get => schedule;
        set
        {
            schedule = value;
            OnPropertyChanged();
        }
    }
    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Activities = await registeredActivitiesFacade.GetAsync();
        Schedule = CreateScheduleList();
    }

    public List<string> CreateScheduleList()
    {
        var scheduleList = new List<string>();

        for (int i = 0; i < 5; i++) // 5 days a week
        {
            for (int j = 0; j < 13; j++) // 13 hours from 7 to 19
            {
                var activities = Activities.Where(a => (int)a.Start.DayOfWeek == i + 1 && a.Start.Hour == 7 + j);
                if (activities.Any())
                {
                    var activity = activities.First();
                    scheduleList.Add($"{activity.ActivityName}\n{activity.Room}");
                }
                else
                {
                    scheduleList.Add("");
                }
            }
        }

        return scheduleList;
    }
}

