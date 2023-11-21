using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Zoo.Web;
using Zoo.Web.Services;
using Zoo.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7112/") });
builder.Services.AddScoped<IZooAnimalsService, ZooAnimalsService>();
await builder.Build().RunAsync();
