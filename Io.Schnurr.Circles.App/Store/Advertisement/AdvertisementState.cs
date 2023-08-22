using Fluxor;
using Io.Schnurr.Circles.App.Store.Base;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

[FeatureState]
[PersistState("circles-advertisement")]
public record AdvertisementState : BaseState
{
    internal IEnumerable<Shared.Models.Advertisement> Items { get; init; }

    public AdvertisementState() { }
}