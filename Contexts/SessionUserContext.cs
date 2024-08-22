namespace BlazorClient.Contexts;

public class SessionUserContext : ISessionUserContext
{
    public bool IsAuthorized { get; set; }
    public string Token { get; set; } = string.Empty;

    public void Login(string userName)
    {
        IsAuthorized = true;
    }

    public void Logout()
    {
        IsAuthorized = false;
    }
}
