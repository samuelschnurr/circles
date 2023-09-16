using Fluxor;
using Io.Schnurr.Circles.App.Services;
using static Io.Schnurr.Circles.App.Features.Offer.Store.OfferActions;

namespace Io.Schnurr.Circles.App.Features.Offer.Store;

public class OfferEffects
{
    private readonly AdvertisementService advertisementService;

    public OfferEffects(AdvertisementService advertisementService)
    {
        this.advertisementService = advertisementService;
    }

    [EffectMethod(typeof(LoadAdvertisementsAction))]
    public async Task LoadAdvertisements(IDispatcher dispatcher)
    {
        var dataTask = advertisementService.GetByUser();

        dispatcher.Dispatch(new SetOfferStateIsLoadingAction(true));

        var data = await dataTask;
        dispatcher.Dispatch(new SetAdvertisementsAction(data));

        dispatcher.Dispatch(new SetOfferStateIsLoadingAction(false));
    }
}