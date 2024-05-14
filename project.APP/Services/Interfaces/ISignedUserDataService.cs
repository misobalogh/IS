namespace project.App.Services;

public interface IStudentDataService
{
    public void SetCurrentUser(object user);
    public void ClearCurrentUser();
    
}
