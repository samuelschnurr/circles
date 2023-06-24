using Io.Schnurr.Circles.App.Interfaces;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;

public partial class AdvertisementTable : ILoadingComponent
{
    [Parameter]
    public IEnumerable<Advertisement> Data { get; init; }

    public bool IsLoading => Data == null;
}
