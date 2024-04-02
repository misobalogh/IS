using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record SubjectModel : ModelBase
{
    public required Guid SubjectId { get; set; }
    public required string SubjectName { get; set; }
    public required string SubjectTag { get; set; }
    public double TotalPoints { get; set; }
    public string? SubjectDescription { get; set;}
    
    // These attributes describe time complexity of lectures, projects
    public int? LecturesHours { get; set; }
    public int? ProjectHours {  get; set; } 
    public string? LessonPlan { get; set;}
    public string? ProjectInfo { get; set;}

    public ObservableCollection<LectureModel> Lectures { get; set; } = new();

    public static SubjectModel Empty => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectTag = string.Empty,
    };
};
