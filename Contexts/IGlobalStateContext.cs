namespace BlazorClient.Contexts
{
    public interface IGlobalStateContext
    {
        GlobalStateContext.StateData State { get; }

        bool SetLoading(bool loading);
    }
}