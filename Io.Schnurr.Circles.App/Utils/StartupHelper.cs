using Fluxor;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Store.Advertisement;
using Io.Schnurr.Circles.App.Store.App;
using Io.Schnurr.Circles.App.Store.Board;
using Io.Schnurr.Circles.App.Store.Middleware;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Io.Schnurr.Circles.App.Utils;

internal static class StartupHelper
{
    internal static void AddApiConfiguration(this WebAssemblyHostBuilder builder)
    {
        var baseAddress = builder.Configuration["ApiHttpsPath"] ?? throw new Exception("Api Path not found");

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        });
    }

    internal static void AddFluxorConfiguration(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddFluxor(options =>
        {
            options.ScanAssemblies(typeof(Program).Assembly);
            options.AddMiddleware<StateInitialization>();
            options.AddMiddleware<StatePersistance<AppState>>();
            options.AddMiddleware<StatePersistance<BoardState>>();
            options.AddMiddleware<StatePersistance<AdvertisementState>>();
#if DEBUG
            options.UseReduxDevTools(rdt =>
            {
                rdt.Name = nameof(Circles);
            });
#endif
        });
    }

    internal static void AddServiceConfiguration(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped<AdvertisementService>();
    }
}