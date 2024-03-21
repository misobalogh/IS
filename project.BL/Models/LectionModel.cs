using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record LectionModel : ModelBase
{
    public required Guid LectionModelId { get; set; }
    public required Days Day { get; set; }
    public required TimeSpan Duration { get; set; }
    public required ActivityType ActivityType { get; set; }
    public required Place Place { get; set; }
    public ObservableCollection<SubjectModel> Subject { get; set; } = new();
    public ObservableCollection<HourSettingModel> HourSettingModelId { get; init; } = new();

    public static LectionModel Empty => new()
    {
        LectionModelId = Guid.Empty,
        Id = Guid.Empty,
        Day = Days.None,
        Duration = TimeSpan.Zero,
        ActivityType = ActivityType.None,
        Place = Place.None,
    };
}
