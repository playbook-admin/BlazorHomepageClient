namespace BlazorClient.Contexts
{
    public interface ISessionUserContext
    {
        bool IsAuthorized { get; set; }

        string Token { get; set; }

        void Login(string userName);
        void Logout();
    }
}