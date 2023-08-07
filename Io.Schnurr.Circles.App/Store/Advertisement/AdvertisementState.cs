using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

[FeatureState]
public record AdvertisementState
{
    internal IEnumerable<Shared.Models.Advertisement>? Items { get; init; } = null;

    public AdvertisementState() { }
}