using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record SubjectModel : ModelBase
{
    public required string Name { get; set; }
    public required string Tag { get; set; }
    public Semester Semester { get; set; }
    public double TotalPoints { get; set; }
    public string? SubjectDescription { get; set;}
    
    // These attributes describe time complexity of lectures, projects
    public int? LectureHours { get; set; }
    public int? ProjectHours {  get; set; } 
    public string? LecturePlan { get; set;}
    public string? ProjectInfo { get; set;}

    public static SubjectModel Empty => new()
    {
        Name = string.Empty,
        Tag = string.Empty,
    };
};
