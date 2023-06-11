using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Board;

public class BoardEffects
{
    private readonly ILocalStorageService localStorageService;
    private readonly IState<BoardState> boardState;
    private const string persistanceName = "circles-board";

    public BoardEffects(ILocalStorageService localStorageService, IState<BoardState> boardState)
    {
        this.localStorageService = localStorageService;
        this.boardState = boardState;
    }

    [EffectMethod(typeof(PersistBoardState))]
    public async Task PersistBoardState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, boardState!.Value);
    }

    [EffectMethod(typeof(InitializeBoardState))]
    public async Task InitializeBoardState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new SetDefaultBoardState());
            dispatcher.Dispatch(new PersistBoardState());
        }
        else
        {
            dispatcher.Dispatch(new SetBoardState(storageState));
        }
    }
}

public record SetBoardState(BoardState BoardState);
public record PersistBoardState();
public record InitializeBoardState();