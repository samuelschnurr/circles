using Fluxor;
using Io.Schnurr.Circles.App.Services;

namespace Io.Schnurr.Circles.App.Store.Advertisement;

public class AdvertisementEffects
{
    private readonly AdvertisementService advertisementService;

    public AdvertisementEffects(AdvertisementService advertisementService)
    {
        this.advertisementService = advertisementService;
    }

    [EffectMethod(typeof(LoadAdvertisementsAction))]
    public async Task LoadAdvertisements(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAdvertisementStateIsLoadingAction(true));
        var data = await advertisementService.GetAll();
        dispatcher.Dispatch(new SetAdvertisementsAction(data));
        dispatcher.Dispatch(new SetAdvertisementStateIsLoadingAction(false));
    }
}

public record LoadAdvertisementsAction();