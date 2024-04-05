using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.BL.Models;

public record StudentListModel : ModelBase
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Uri? PhotoUrl { get; set; }
    //Grade means year of study
    public required int Grade { get; set; }
    
    public static StudentListModel Empty => new()
    {
        Id = Guid.Empty,
        FirstName = string.Empty,
        LastName = string.Empty,
        Grade = 0
    };
}
