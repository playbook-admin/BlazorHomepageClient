using BlazorClient.Models;
using BlazorClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Json;

namespace BlazorClient;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // Configure HttpClient
        var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

        try
        {
            // Fetch appsettings.json
            var appSettings = await httpClient.GetFromJsonAsync<AppSettings>("appsettings.json");

            if (appSettings == null)
            {
                throw new Exception("Failed to load appsettings.json");
            }

            // Use settings to configure HttpClient
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(appSettings.ApiBaseAddress) });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error loading appsettings.json: {ex.Message}");
        }

        await builder.Build().RunAsync();
    }
}


