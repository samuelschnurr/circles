using Fluxor;
using Io.Schnurr.Circles.App.Features.Base.Store;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.App.Features.Offer.Store;

[FeatureState]
[PersistState("circles-offer")]
public record OfferState : BaseState
{
    internal IEnumerable<Advertisement> Items { get; init; }

    public OfferState() { }
}