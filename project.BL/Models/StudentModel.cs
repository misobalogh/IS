using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BL.Models;

public record StudentModel : ModelBase
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Uri? Image { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    //Grade means year of study
    public required int Grade { get; set; }
    public ObservableCollection<EnrolledSubjectsListModel> EnrolledSubjects { get; set; } = new();
    public ObservableCollection<RegisteredActivitiesListModel> RegisteredActivities { get; set; } = new();
    public ObservableCollection<EvaluationListModel> Evaluation { get; set; } = new();
    
    public static StudentModel Empty => new()
    {
        Id = Guid.Empty,
        Password = string.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Grade = 0,
        Email = string.Empty
    };
}

