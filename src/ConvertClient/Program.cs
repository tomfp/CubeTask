using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ConvertClient;
using ConvertClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string? conversionApiBase = builder.Configuration[ConfigValues.ConversionApi];
if (string.IsNullOrWhiteSpace(conversionApiBase))
{
    throw new ArgumentNullException("Invalid ConversionAPI setting in appsettings.json");
}
builder.Services.AddHttpClient(ConfigValues.ConversionApi, client => 
{
    client.BaseAddress = new Uri(conversionApiBase);
});

builder.Services.AddScoped<ITemperatureService, TemperatureService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
