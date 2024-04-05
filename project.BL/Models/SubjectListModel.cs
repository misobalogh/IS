using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record SubjectListModel : ModelBase
{
    public required string SubjectName { get; set; }
    public required string SubjectTag { get; set; }

    public static SubjectListModel Empty => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = string.Empty,
        SubjectTag = string.Empty,
    };
};
