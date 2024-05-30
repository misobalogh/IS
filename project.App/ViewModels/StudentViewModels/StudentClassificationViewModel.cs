using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;
using project.BL.Facades.Interfaces;

namespace project.App.ViewModels;

public partial class StudentClassificationViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IActivityFacade activityFacade,
    IEvaluationFacade evaluationFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;

    public string SubjectBtn { get; set; } = "Subject";
    public string PointsBtn { get; set; } = "Points";
    public string MarkBtn { get; set; } = "Mark";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        Subject,
        Points,
        Mark,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (loggedUser ==  null) { return; }

        var allEnrolledSubjects = await enrolledSubjectsFacade.GetAsync();
        var allActivities = await activityFacade.GetAsync();
        var allEvaluations = await evaluationFacade.GetAsync();

        var relevantEnrolledSubjects = allEnrolledSubjects.Where(subject => subject.StudentId == loggedUser.Id);

        var relevantActivities = allActivities
            .Where(a => relevantEnrolledSubjects
                .Select(es => es.SubjectId)
                .Contains(a.SubjectId)
            );

        foreach (var enrolledSubject in relevantEnrolledSubjects)
        {
            var subjectActivities = relevantActivities.Where(a => a.SubjectId == enrolledSubject.SubjectId);

            var totalPoints = allEvaluations
                .Where(e => subjectActivities.Select(a => a.Id).Contains(e.ActivityId))
                .Sum(e => e.Points);

            var modifyES = await enrolledSubjectsFacade.GetAsync(enrolledSubject.Id);
            if (modifyES == null) { continue; }
            modifyES.Points = totalPoints;
            await enrolledSubjectsFacade.SaveAsync(modifyES, loggedUser.Id);
        }

        EnrolledSubjects = (await enrolledSubjectsFacade.GetAsync()).Where(subject => subject.StudentId == loggedUser.Id);
        SortBySubject();
    }

    [RelayCommand]
    async Task ShowSubjectDetails(object clickedItem)
    {
        if (clickedItem == null) { 
            return; 
        }

        if (clickedItem is EnrolledSubjectsListModel subject) {
            var route = $"{nameof(StudentClassificationSubjectDetailView)}?subjectId={subject.SubjectId}";
            await Shell.Current.GoToAsync(route);
        }
    }

    [RelayCommand]
    void SortBySubject()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Subject);

        SubjectBtn = GetSortColName(SubjectBtn);

        EnrolledSubjects = enrolledSubjectsFacade.Sort(EnrolledSubjects, nameof(EnrolledSubjectsListModel.SubjectName), SortDescending);

        SortedBy = SortBy.Subject;
    }

    [RelayCommand]
    void SortByPoints()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Points);

        PointsBtn = GetSortColName(PointsBtn);

        EnrolledSubjects = enrolledSubjectsFacade.Sort(EnrolledSubjects, nameof(EnrolledSubjectsListModel.Points), SortDescending);

        SortedBy = SortBy.Points;
    }

    [RelayCommand]
    void SortByMark()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Mark);

        MarkBtn = GetSortColName(MarkBtn);

        EnrolledSubjects = enrolledSubjectsFacade.Sort(EnrolledSubjects, nameof(EnrolledSubjectsListModel.Mark), SortDescending);

        SortedBy = SortBy.Mark;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        SubjectBtn = "Subject";
        PointsBtn = "Points";
        MarkBtn = "Mark";
    }

    /// <summary>
    /// if clicked on column by which is already sorted -> change direction of sort
    /// </summary>
    private void ChangeSortDirectionIfSorted(SortBy newSortBy)
    {
        if (newSortBy == SortedBy)
        {
            SortDescending = !SortDescending;
        }
        else // if switched to sorting by different column, set to descending
        {
            SortDescending = false;
        }
    }

    private string GetSortColName(string colName)
    {
        if (SortDescending)
        {
            return colName + " ↓";
        }
        else
        {
            return colName + " ↑";
        }
    }
}

