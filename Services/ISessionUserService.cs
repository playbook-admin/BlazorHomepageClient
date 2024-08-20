namespace BlazorClient.Services
{
    public interface ISessionUserService
    {
        bool IsLoggedIn { get; set; }

        void Login(string userName);
        void Logout();
    }
}