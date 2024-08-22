namespace BlazorClient.Contexts
{
    public interface IGlobalStateContext
    {
        string ApiAddress { get; set; }
        string Loading { get; set; }
    }
}