namespace BlazorClient.Contexts
{
    public interface ISessionUserContext
    {
        SessionUserContext.StateData State { get; }

        void Login(string userName);
        Task<string> LogoutAsync();

        Task<string> CheckPasswordAsync(string password);
    }
}