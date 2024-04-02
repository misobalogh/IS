namespace project.BL.Models;

public record HourSettingModel : ModelBase
{
    public required DateTime StartTime { get; set; }
    public required DateTime EndTime { get; set; }

    public static HourSettingModel Empty => new() 
    {
        StartTime = DateTime.Now,
        EndTime = DateTime.Now,
    };
}

