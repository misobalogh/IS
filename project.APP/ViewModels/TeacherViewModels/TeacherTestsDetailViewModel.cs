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
    IStudentFacade studentFacade,
    IRegisteredActivitiesFacade registeredActivitiesFacade,
    IEvaluationFacade evaluationFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{
    public string? ActivityId { get; set; }

    public ActivityModel? Activity { get; private set; }
    public IEnumerable<StudentListModel> Students { get; private set; } = null!;
    public IEnumerable<RegisteredActivitiesListModel> RegisteredActivities { get; private set; } = null!;
    public IEnumerable<EvaluationListModel> Evaluation { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        if (ActivityId == null)
            return;
        await base.LoadDataAsync();
        Activity = await activityFacade.GetAsync(Guid.Parse(ActivityId));
        Students = await studentFacade.GetAsync();
        RegisteredActivities = await registeredActivitiesFacade.GetAsync();
        if (Activity != null)
        {
            RegisteredActivities = RegisteredActivities.Where(x => x.ActivityId == Guid.Parse(ActivityId));
            IEnumerable<StudentListModel> FilteredStudents = new List<StudentListModel>();
            foreach (var activity in RegisteredActivities)
            {
                var st = Students.Where(x => x.Id == activity.StudentId);
                foreach (var student in st)
                {
                    FilteredStudents = FilteredStudents.Append(student);
                }
            }

            Students = FilteredStudents;
            

            //IEnumerable<Ev>
            //foreach (var evaluationStudent in Students)
            //{
            //    var ev = Evaluation.Where(x => x.StudentId == evaluationStudent.Id);
            //    foreach()
            //}
            //TODO: add points
        }
    }
}
