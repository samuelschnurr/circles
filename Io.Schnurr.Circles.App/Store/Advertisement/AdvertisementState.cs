using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

[FeatureState]
[PersistState("circles-advertisement")]
public record AdvertisementState
{
    internal IEnumerable<Shared.Models.Advertisement>? Items { get; init; } = null;

    public AdvertisementState() { }
}