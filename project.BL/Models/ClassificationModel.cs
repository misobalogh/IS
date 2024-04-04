using System.Collections.ObjectModel;

namespace project.BL.Models;

public record ClassificationModel : ModelBase
{
    public required string SemesterName { get; set; }
    public ObservableCollection<ActivityListModel> ActivityPoints { get; set; } = new();

    public static ClassificationModel Empty => new()
    {
        SemesterName = string.Empty
    };
}
