using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentScheduleViewModel : StudentNavigationSideBar, INotifyPropertyChanged
{
    private readonly IRegisteredActivitiesFacade registeredActivitiesFacade;

    public StudentScheduleViewModel(IRegisteredActivitiesFacade registeredActivitiesFacade, IMessengerService messengerService)
        : base(messengerService)
    {
        this.registeredActivitiesFacade = registeredActivitiesFacade;
        Schedule = new List<string>();
    }

    public IEnumerable<RegisteredActivitiesListModel> Activities { get; set; } = null!;

    private List<string> schedule;
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}

