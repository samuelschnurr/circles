using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.App.Features.Offer.Store;

public abstract class OfferActions
{
    public record LoadAdvertisementsAction();
    public record SetAdvertisementsAction(IEnumerable<Advertisement>? Advertisements);
    public record SetOfferStateIsLoadingAction(bool IsLoading);
}
