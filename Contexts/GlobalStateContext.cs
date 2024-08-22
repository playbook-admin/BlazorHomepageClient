namespace BlazorClient.Contexts
{
    public class GlobalStateContext : IGlobalStateContext
    {
        // Define the nested State class
        public class StateData
        {
            public bool Loading { get; set; } 
            public string ApiAddress { get; set; } = string.Empty;
        }

        // Property to hold the state
        public StateData State { get; private set; } = new StateData();

        public GlobalStateContext(IConfiguration configuration)
        {
            State.ApiAddress = configuration["ApiAddress"];
        }

        public void SetApiAddress(string apiAddress)
        {
            State.ApiAddress = apiAddress;
        }

        public bool SetLoading(bool loading)
        {
            State.Loading = loading;
            return loading;
        }
    }
}
