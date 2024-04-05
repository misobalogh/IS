using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.DAL.Enums;

namespace project.BL.Models;

public record TeacherModel : ModelBase
{
    public TitleBefore? TitleBefore { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public TitleAfter? TitleAfter { get; set; }
    public required string Password { get; set; }
    public Uri? PhotoUrl { get; set; }
    public required string Email { get; set; }

    public ObservableCollection<SubjectListModel> TeachingSubjects { get; set; } = new();
    
    public static TeacherModel Empty => new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Password = string.Empty,
        Email = string.Empty
    };
}
