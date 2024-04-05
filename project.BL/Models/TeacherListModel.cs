using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.DAL.Enums;

namespace project.BL.Models;

public record TeacherListModel : ModelBase
{
    public TitleBefore? TitleBefore { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public TitleAfter? TitleAfter { get; set; }
    public Uri? PhotoUrl { get; set; }
    
    public static TeacherListModel Empty => new()
    {
        TeacherId = Guid.Empty,
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty
    };
}
