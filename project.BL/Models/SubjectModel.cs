using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record SubjectModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectTag { get; set; }
    public DateTime Year { get; set; }
    public Semester Semester { get; set; }
    public double TotalPoints { get; set; }
    public string? SubjectDescription { get; set;}
    
    // These attributes describe time complexity of lectures, projects
    public int? LectureHours { get; set; }
    public int? ProjectHours {  get; set; } 
    public string? LecturePlan { get; set;}
    public string? ProjectInfo { get; set;}

    public ObservableCollection<ActivityListModel> Activities { get; set; } = new();

    public static SubjectModel Empty => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectTag = string.Empty,
    };
};
