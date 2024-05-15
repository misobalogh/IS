namespace project.App.Services;

public interface IUserDataService
{
    public void SetCurrentUser(object user);
    public void ClearCurrentUser();
    
}
