namespace project.BL.Models;

public record HourSettingModel : ModelBase
{
    public required TimeSpan StartTime { get; set; }
    public required TimeSpan EndTime { get; set; }

    public static HourSettingModel Empty => new() 
    {
        StartTime = TimeSpan.Zero,
        EndTime = TimeSpan.Zero,
    };
}

