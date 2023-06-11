using Fluxor;
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
            options.AddMiddleware<InitializationMiddleware>();
#if DEBUG
            options.UseReduxDevTools(rdt =>
            {
                rdt.Name = nameof(Circles);
            });
#endif
        });
    }
}