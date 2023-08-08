using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public class BoardEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-board";

    public BoardEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetStateAction(new BoardState() with { IsTileView = true }));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

public record InitializeStateAction();