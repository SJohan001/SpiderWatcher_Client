using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpiderWatcher_Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseDeAddress = "http://localhost:8088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseDeAddress) });

await builder.Build().RunAsync();
