using FluentValidation;
using Fluxor;
using Io.Schnurr.Circles.App.Middlewares;
using Io.Schnurr.Circles.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Utils;

internal static class StartupHelper
{
    internal static void AddApiConfiguration(this WebAssemblyHostBuilder builder)
    {
        var baseAddress = builder.Configuration["ApiHttpsPath"] ?? throw new Exception("Api Path not found");

        builder.Services.AddHttpClient(nameof(HttpClient), sp =>
        {
            sp.BaseAddress = new Uri(baseAddress);
        }).AddHttpMessageHandler<HttpStatusCodeService>();

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(HttpClient)));
    }

    internal static void AddFluxorConfiguration(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddFluxor(options =>
        {
            options.ScanAssemblies(typeof(Program).Assembly);
            options.AddMiddleware<StateInitialization>();
            options.AddMiddleware<StatePersistance>();
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
        builder.Services.AddSingleton<ISnackbar, SnackbarService>();
        builder.Services.AddSingleton<HttpStatusCodeService>();

        builder.Services.AddScoped<AdvertisementService>();
    }

    internal static void AddFluentValidationConfiguration()
    {
        // Provide only english messages
        ValidatorOptions.Global.LanguageManager.Enabled = false;
    }
}