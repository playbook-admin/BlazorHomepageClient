namespace BlazorClient.Services;

public class SessionUserService : ISessionUserService
{
    public bool IsAuthorized { get; set; }

    public void Login(string userName)
    {
        IsAuthorized = true;
    }

    public void Logout()
    {
        IsAuthorized = false;
    }
}
