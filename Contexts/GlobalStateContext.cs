namespace BlazorClient.Contexts;

public class GlobalStateContext : IGlobalStateContext
{
    public string Loading { get; set; } = string.Empty;
    public string ApiAddress { get; set; } = string.Empty;

    public GlobalStateContext(IConfiguration configuration)
    {
        ApiAddress = configuration["ApiAddress"];
    }

    public void SetApiAddress(string apiAddress)
    {
        ApiAddress = apiAddress;
    }
}
