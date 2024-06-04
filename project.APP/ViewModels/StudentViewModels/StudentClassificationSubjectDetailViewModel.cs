using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class StudentClassificationSubjectDetailViewModel(
    IEvaluationFacade evaluationFacade,
    IActivityFacade activityFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{
    public string? SubjectId { get; set; }
    public ObservableCollection<ActivityEvaluation> ActivityEvaluation { get; private set; } = new ObservableCollection<ActivityEvaluation>();


    protected override async Task LoadDataAsync()
    {
        if (SubjectId == null)
        {
            return;
        }

        await base.LoadDataAsync();
        if (loggedUser == null)
        {
            return;
        }

        var allActivities = await activityFacade.GetAsync();
        var allEvaluations = await evaluationFacade.GetAsync();

        var relevantActivities = allActivities.Where(a => a.SubjectId == Guid.Parse(SubjectId)).ToList();   
        if (relevantActivities.Count == 0) { return; }

        var activityIds = relevantActivities.Select(a => a.Id).ToList();        

        foreach (var activity in relevantActivities)
        {
            var relevantEvaluation = allEvaluations
                .Where(e => e.ActivityId == activity.Id && e.StudentId == loggedUser.Id && activityIds.Contains(e.ActivityId))
                .FirstOrDefault();                

            ActivityEvaluation.Add(new() { activityModel = activity, evaluationModel = relevantEvaluation });
        }
    }
}

public class ActivityEvaluation
{
    public required EvaluationListModel evaluationModel { get; set; }
    public required ActivityListModel activityModel { get; set; }
}
