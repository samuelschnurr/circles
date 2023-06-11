using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public class BoardEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<BoardState> state;
    private const string persistanceName = "circles-board";

    public BoardEffects(ILocalStorageService localStorageService, IState<BoardState> state)
    {
        this.localStorageService = localStorageService;
        this.state = state;
    }

    [EffectMethod(typeof(PersistState))]
    public async Task PersistState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, state!.Value);
    }

    [EffectMethod(typeof(InitializeState))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultState());
            dispatcher.Dispatch(new PersistState());
        }
        else
        {
            dispatcher.Dispatch(new SetState(storageState));
        }
    }
}

public record SetState(BoardState state);
public record PersistState();
public record InitializeState();