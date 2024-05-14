using project.BL.Models;

namespace project.App.Services;

public class StudentDataService : IStudentDataService
{
    public StudentModel? CurrentStudent { get; private set; }

    public void SetCurrentUser(object user)
    {
        if (user is StudentModel student)
        {
            CurrentStudent = student;
        }
    }

    public void ClearCurrentUser()
    {
        CurrentStudent = null;
    }
}
