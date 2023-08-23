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
        var dataTask = advertisementService.GetAll();

        dispatcher.Dispatch(new SetAdvertisementStateIsLoadingAction(true));

        var data = await dataTask;
        dispatcher.Dispatch(new SetAdvertisementsAction(data));

        dispatcher.Dispatch(new SetAdvertisementStateIsLoadingAction(false));
    }
}

public record LoadAdvertisementsAction();