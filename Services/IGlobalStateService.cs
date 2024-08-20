namespace BlazorClient.Services
{
    public interface IGlobalStateService
    {
        string ApiAddress { get; set; }
        string Loading { get; set; }
    }
}