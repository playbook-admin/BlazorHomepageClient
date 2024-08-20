namespace BlazorClient.Services;

public class GlobalStateService : IGlobalStateService
{
    public string Loading { get; set; } = string.Empty;
    public string ApiAddress { get; set; } = string.Empty;

    public GlobalStateService(IConfiguration configuration)
    {
        ApiAddress = configuration["ApiAddress"];
    }

    public void SetApiAddress(string apiAddress)
    {
        ApiAddress = apiAddress;
    }
}
