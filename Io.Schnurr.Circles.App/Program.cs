using Blazored.LocalStorage;
using Io.Schnurr.Circles.App;
using Io.Schnurr.Circles.App.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.AddApiConfiguration();
builder.AddFluxorConfiguration();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
