using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Mappers;
using project.BL.Models;

namespace project.App.ViewModels;

[QueryProperty(nameof(ActivityId), "activityId")]
public partial class TeacherTestsDetailViewModel(
    IActivityFacade activityFacade,
    IStudentFacade studentFacade,
    IEvaluationFacade evaluationFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public string? ActivityId { get; set; }

    public ActivityModel? Activity { get; private set; }
    public ICollection<StudentListModel> Students { get; private set; } = new List<StudentListModel>();
    public IEnumerable<RegisteredActivitiesListModel> RegisteredActivities { get; private set; } = null!;
    public IEnumerable<EvaluationListModel> Evaluations { get; private set; } = null!;
    public ObservableCollection<StudentEvaluationModel> StudentEvaluations { get; private set; } = new ObservableCollection<StudentEvaluationModel>();
    protected override async Task LoadDataAsync()
    {
        if (ActivityId == null){
            return;
        }
        await base.LoadDataAsync();

        Activity = await activityFacade.GetAsync(Guid.Parse(ActivityId));
        if (Activity == null) { return; }

        var allStudents = await studentFacade.GetAsync();
        var allEvaluations = await evaluationFacade.GetAsync();
        var activityEvaluations = allEvaluations.Where(e => e.ActivityId == Activity.Id).ToList();

        foreach (var student in allStudents)
        {
            var studentDetail = await studentFacade.GetAsync(student.Id);
            if (studentDetail == null) continue;

            var isRegisteredForActivity = studentDetail.RegisteredActivities.Any(ra => ra.ActivityId == Activity.Id);
            if (isRegisteredForActivity)
            {
                var evaluationId = activityEvaluations.FirstOrDefault(e => e.StudentId == student.Id && e.ActivityId == Activity.Id)?.Id;
                EvaluationModel? evaluation = null;
                if (evaluationId != null)
                {
                    evaluation = await evaluationFacade.GetAsync((Guid)evaluationId);
                }
                StudentEvaluations.Add(new StudentEvaluationModel(student, evaluation, Activity.Id, evaluationFacade));
            }
        }
    }
}
public partial class StudentEvaluationModel : ObservableObject
{
    [ObservableProperty]
    public bool isEditMode;

    [ObservableProperty]
    public string? editPoints;

    public StudentListModel Student { get; set; }
    public EvaluationModel Evaluation { get; set; }
    private IEvaluationFacade evaluationFacade {  get; set; }
    public StudentEvaluationModel(StudentListModel Student, EvaluationModel? Evaluation, Guid ActivityId, IEvaluationFacade evaluationFacade)
    {
        this.Student = Student;
        this.Evaluation = Evaluation ?? new()
        {
            Points = 0,
            StudentId = Student.Id,
            Id = Guid.NewGuid(),
            ActivityId = ActivityId
        };
        EditPoints = Evaluation?.Points.ToString() ?? string.Empty;
        this.evaluationFacade = evaluationFacade;
    }

    [RelayCommand]
    private void EnableEditMode()
    {
        IsEditMode = true;
        EditPoints = Evaluation?.Points.ToString() ?? string.Empty;
    }

    [RelayCommand]
    private async Task SavePoints()
    {
        if (Evaluation != null && int.TryParse(EditPoints, out var newPoints))
        {
            Evaluation.Points = newPoints;
            await evaluationFacade.SaveAsync(Evaluation);

        }
        IsEditMode = false;
    }
}

