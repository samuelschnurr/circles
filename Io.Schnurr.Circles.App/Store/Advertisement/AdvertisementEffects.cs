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
        var data = await advertisementService.GetAll();
        dispatcher.Dispatch(new SetAdvertisementsAction(data));
    }
}

public record LoadAdvertisementsAction();