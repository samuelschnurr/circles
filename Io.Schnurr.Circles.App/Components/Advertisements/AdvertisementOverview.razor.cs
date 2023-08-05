using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;

public partial class AdvertisementOverview
{
    [Parameter]
    public IEnumerable<Advertisement> Data { get; init; }

    [Parameter]
    public bool IsDrawerOpen { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    public bool IsLoading => Data == null;
}
