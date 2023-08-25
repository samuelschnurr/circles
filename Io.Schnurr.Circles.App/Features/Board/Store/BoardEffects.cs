using Fluxor;
using Io.Schnurr.Circles.App.Services;

namespace Io.Schnurr.Circles.App.Features.Board.Store;

public class BoardEffects
{
    private readonly AdvertisementService advertisementService;

    public BoardEffects(AdvertisementService advertisementService)
    {
        this.advertisementService = advertisementService;
    }

    [EffectMethod(typeof(LoadAdvertisementsAction))]
    public async Task LoadAdvertisements(IDispatcher dispatcher)
    {
        var dataTask = advertisementService.GetAll();

        dispatcher.Dispatch(new SetBoardStateIsLoadingAction(true));

        var data = await dataTask;
        dispatcher.Dispatch(new SetAdvertisementsAction(data));

        dispatcher.Dispatch(new SetBoardStateIsLoadingAction(false));
    }
}

public record LoadAdvertisementsAction();