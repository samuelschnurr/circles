using Blazored.LocalStorage;
using Io.Schnurr.Circles.App;
using Io.Schnurr.Circles.App.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.AddFluxorConfiguration();

builder.Services.AddMudServices();
builder.AddServiceConfiguration();
builder.AddApiConfiguration();

StartupHelper.AddFluentValidationConfiguration();

await builder.Build().RunAsync();
