using project.BL.Models;

namespace project.App.Services;

public class UserDataService : IUserDataService
{
    public StudentModel? CurrentStudent { get; private set; }
    public TeacherModel? CurrentTeacher { get; private set; }
    public string? CurrentAdmin { get; private set; }

    public void SetCurrentUser(object user)
    {
        if (user is StudentModel student)
        {
            CurrentStudent = student;
        }

        if (user is TeacherModel teacher)
        {
            CurrentTeacher = teacher;
        }

        else if (user is string admin && admin == "admin") 
        {
            CurrentAdmin = admin;
        }
    }

    public void ClearCurrentUser()
    {
        CurrentStudent = null;
        CurrentTeacher = null;
        CurrentAdmin = null;
    }
}
