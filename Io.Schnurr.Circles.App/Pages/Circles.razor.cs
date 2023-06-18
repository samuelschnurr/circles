using System.Net.Http.Json;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Circles
{
    [Inject]
    private HttpClient HttpClient { get; set; } = default!;

    protected Offer[]? offers;
    protected override async Task OnInitializedAsync()
    {
        offers = await HttpClient.GetFromJsonAsync<Offer[]>("offer");
    }
}
