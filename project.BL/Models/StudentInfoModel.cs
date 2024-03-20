using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BL.Models;

public record StudentInfoModel : ModelBase
{
    public required Guid StudentInfoId { get; set; }
    public required string StudentName { get; set; }
    public required int StudentGrade { get; set; }
    public required double StudentPoints { get; set; }

    public static StudentInfoModel Empty => new()
    {
        StudentInfoId = Guid.Empty,
        Id = Guid.Empty,
        StudentName = string.Empty,
        StudentGrade = 0,
        StudentPoints = 0,
    };
}

