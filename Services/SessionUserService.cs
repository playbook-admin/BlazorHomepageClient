namespace BlazorClient.Services;

public class SessionUserService
{
    public bool IsLoggedIn { get; set; }

    public void Login(string userName)
    {
        IsLoggedIn = true;
    }

    public void Logout()
    {
        IsLoggedIn = false;
    }
}
