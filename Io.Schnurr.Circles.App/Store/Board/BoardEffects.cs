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

    [EffectMethod(typeof(OnPersistBoardStateAction))]
    public async Task PersistState(IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, boardState!.Value);
    }

    [EffectMethod(typeof(OnInitializeBoardStateAction))]
    public async Task InitializeBoardStateAction(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new OnSetDefaultBoardStateAction());
            dispatcher.Dispatch(new OnPersistBoardStateAction());
        }
        else
        {
            dispatcher.Dispatch(new OnSetBoardStateAction(storageState));
        }
    }
}

public record OnSetBoardStateAction(BoardState BoardState);
public record OnPersistBoardStateAction();
public record OnInitializeBoardStateAction();