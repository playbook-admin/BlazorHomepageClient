namespace BlazorClient.Services
{
    public interface ISessionUserService
    {
        bool IsAuthorized { get; set; }

        void Login(string userName);
        void Logout();
    }
}