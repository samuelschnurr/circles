using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Board;

public class BoardEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<BoardState> boardState;

    public BoardEffects(ILocalStorageService localStorageService, IState<BoardState> boardState)
    {
        this.localStorageService = localStorageService;
        this.boardState = boardState;
    }

    [EffectMethod(typeof(PersistStateAction<BoardState>))]
    public async Task PersistState()
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<BoardState>();
        await localStorageService.SetItemAsync(persistanceName, boardState.Value);
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var persistanceName = PersistStateAttribute.GetPersistanceName<BoardState>();
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultStateAction());
        }
        else
        {
            dispatcher.Dispatch(new SetStateFromLocalStorageAction(storageState));
        }
    }
}

[InitializeOnStartup]
public record InitializeStateAction();