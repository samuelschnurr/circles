using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;

public partial class AdvertisementTile
{
    [Parameter]
    public IEnumerable<Advertisement> Data { get; init; }
}
