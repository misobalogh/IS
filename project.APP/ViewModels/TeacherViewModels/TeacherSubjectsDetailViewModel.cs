using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class TeacherSubjectsDetailViewModel(
    ISubjectFacade subjectFacade,
    IActivityFacade activityFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public string? SubjectId { get; set; }

    public SubjectModel? Subject { get; private set; }
    public IEnumerable<ActivityListModel> Activities { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        if (SubjectId == null)
        {
            return;
        }

        await base.LoadDataAsync();
        Subject = await subjectFacade.GetAsync(Guid.Parse(SubjectId));
        Activities = await activityFacade.GetAsync();

        if (/*loggedUser != null && */Subject != null)
        {
            Activities = Activities.Where(activity => Subject.Id == activity.SubjectId);
        }
    }

    [RelayCommand]
    async Task NewActivity()
    {
        // TODO: implement new activity
        await Shell.Current.GoToAsync(nameof(TeacherNewActivityView));
    }

    [RelayCommand]
    async Task EditActivity(object clickedItem)
    {
        if (clickedItem == null)
        {
            return;
        }

        if (clickedItem is ActivityListModel activity)
        {
            // TODO: implement edit activity
            //var route = $"{nameof(TeacherEditActivityView)}?activityId={activity.Id}";
            //await Shell.Current.GoToAsync(route);
        }
    }
}

