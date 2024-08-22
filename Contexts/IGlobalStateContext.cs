namespace BlazorClient.Services
{
    public interface IGlobalStateContext
    {
        string ApiAddress { get; set; }
        string Loading { get; set; }
    }
}