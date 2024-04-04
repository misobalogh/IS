using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BL.Models;

public record StudentModel : ModelBase
{
    public required Guid StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Uri? PhotoUrl { get; set; }
    public required string Email { get; set; }
    //Grade means year of study
    public required int Grade { get; set; }
    public ObservableCollection<EnrolledSubjectsListModel> EnrolledSubjects { get; set; } = new();
    public ObservableCollection<RegisteredActivitiesListModel> RegisteredActivities { get; set; } = new();
    public ObservableCollection<ClassificationModel> Classification { get; set; } = new();
    
    public static StudentModel Empty => new()
    {
        StudentId = Guid.Empty,
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Grade = 0,
        Email = string.Empty
    };
}

