using BlazorClient.Contexts;

public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly ISessionUserContext _sessionUserContext;

    public AuthorizationMessageHandler(ISessionUserContext sessionUserContext)
    {
        _sessionUserContext = sessionUserContext;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _sessionUserContext.State?.Token;
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("*"));

        return await base.SendAsync(request, cancellationToken);
    }
}
