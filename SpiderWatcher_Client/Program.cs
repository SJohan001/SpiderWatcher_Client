using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpiderWatcher_Client;
using SpiderWatcher_Client.Conexion;
using SpiderWatcher_Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var grpcBaseDeAddress = "https://puer.azurewebsites.net";
var blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=spiderwatcherbs;AccountKey=fi8pH/Jt65gddZqKXB+SAXf0F2hGAtqksmRH7j6jBVqFhzqTKGu3tPT2TV0oD0edMo8HlbYqWSJ9+ASt/3odtQ==;EndpointSuffix=core.windows.net";
var containerName = "imagecontent";
builder.Services.AddScoped(sp => new AzureBlobService(blobStorageConnectionString, containerName));

var apiBaseDeAddress = "http://localhost:8088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseDeAddress) });

builder.Services.AddScoped<AuthenticationService>();

builder.Services.AddScoped<NavigationService>();

await builder.Build().RunAsync();
