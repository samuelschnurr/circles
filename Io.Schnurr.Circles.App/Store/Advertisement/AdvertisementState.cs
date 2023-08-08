using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

[FeatureState]
public record AdvertisementState : PersistableState
{
    internal override string PersistanceName => "circles-advertisement";
    internal IEnumerable<Shared.Models.Advertisement>? Items { get; init; } = null;

    public AdvertisementState() { }
}