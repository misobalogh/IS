using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;

namespace project.App.ViewModels;

[QueryProperty(nameof(ActivityId), "activityId")]
public partial class TeacherTestsDetailViewModel(
    IActivityFacade activityFacade,
    IEvaluationFacade evaluationFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public string? ActivityId { get; set; }

    public ActivityModel? Activity { get; private set; }
    public IEnumerable<StudentListModel> Students { get; private set; } = null!;
    public IEnumerable<RegisteredActivitiesListModel> RegisteredActivities { get; private set; } = null!;
    public IEnumerable<EvaluationListModel> Evaluations { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        if (ActivityId == null){
            return;
        }
        await base.LoadDataAsync();

        Activity = await activityFacade.GetAsync(Guid.Parse(ActivityId));
        if (Activity == null) { return; }

        Evaluations = await evaluationFacade.GetAsync();
        Evaluations = Evaluations.Where(eva => eva.ActivityId == Activity.Id);          
    }
}
