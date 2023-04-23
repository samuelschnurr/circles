using System.Net.Http.Json;
using Io.Schnurr.Circles.Shared;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Circles
{
    [Inject]
    private HttpClient HttpClient { get; set; } = default!;

    protected WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await HttpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}
