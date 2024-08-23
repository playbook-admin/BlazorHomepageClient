using System.Text;
using System.Text.Json;

namespace BlazorClient.Contexts;

public class SessionUserContext : ISessionUserContext
{
    private readonly IGlobalStateContext _globalStateContext;
    private readonly IServiceProvider _serviceProvider;

    public class StateData
    {
        public bool IsAuthorized { get; set; }
        public string Token { get; set; } = string.Empty;
    }

    public StateData State { get; private set; } = new StateData();

    public SessionUserContext(IGlobalStateContext globalStateContext, IServiceProvider serviceProvider)
    {
        _globalStateContext = globalStateContext;
        _serviceProvider = serviceProvider;
    }

    public void Login(string token)
    {
        State.IsAuthorized = true;
        State.Token = token;
    }

    public Task<string> LogoutAsync()
    {
        State.IsAuthorized = false;
        State.Token = string.Empty;
        return Task.FromResult("userLoggedOut");
    }

    public async Task<string> CheckPasswordAsync(string password)
    {
        _globalStateContext.SetLoading(true);

        var loginModel = new LoginModel
        {
            Password = password
        };

        // Resolve HttpClient from the service provider
        using var scope = _serviceProvider.CreateScope();
        var httpClient = scope.ServiceProvider.GetRequiredService<HttpClient>();

        var requestContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("api/authorization/login", requestContent);

        _globalStateContext.SetLoading(false);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonSerializer.Deserialize<LoginResponse>(responseContent);

            if (responseObject != null)
            {
                Login(responseObject.token);
            }

            return "PasswordOk";
        }

        // Handle error responses here
        var errorResponse = response.Content.ReadAsStringAsync().Result;
        return errorResponse;
    }

    public class LoginModel
    {
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string token { get; set; } = string.Empty;
    }
}
