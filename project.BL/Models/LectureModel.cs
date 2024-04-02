using System.Collections.ObjectModel;
using project.DAL.Enums;

namespace project.BL.Models;

public record LectureModel : ModelBase
{
    public required Guid LectureModelId { get; set; }
    public required Day Day { get; set; }
    public required ActivityType ActivityType { get; set; }
    public required Place Place { get; set; }
    public ObservableCollection<HourSettingModel> HourSettingModelId { get; init; } = new();

    public static LectureModel Empty => new()
    {
        LectureModelId = Guid.Empty,
        Id = Guid.Empty,
        Day = Day.None,
        ActivityType = ActivityType.None,
        Place = Place.None,
    };
}
