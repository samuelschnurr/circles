using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

[FeatureState]
public record AdvertisementState
{
    public IEnumerable<Shared.Models.Advertisement>? Items { get; init; }

    public AdvertisementState() { }
}