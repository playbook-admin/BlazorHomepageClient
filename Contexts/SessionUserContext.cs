namespace BlazorClient.Contexts;

public class SessionUserContext : ISessionUserContext
{
    public class StateData
    {
        public bool IsAuthorized { get; set; }
        public string Token { get; set; } = string.Empty;
    }
    public StateData State { get; private set; } = new StateData();

    public void Login(string userName)
    {
        State.IsAuthorized = true;
    }

    public Task<string> LogoutAsync()
    {
        State.IsAuthorized = false;
        return Task.FromResult("userLoggedOut");
    }

    public Task<string> CheckPasswordAsync(string password) 
    {
        return Task.FromResult(password);
    }
}
