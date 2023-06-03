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

    [EffectMethod]
    public async Task PersistState(OnPersistBoardStateAction action, IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, action.BoardState);
    }

    [EffectMethod(typeof(OnLoadBoardStateAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        var boardState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (boardState == null)
        {
            dispatcher.Dispatch(new OnInitializeBoardStateAction());
            // TODO: dispatcher.Dispatch(new OnPersistBoardStateAction());
        }
        else
        {
            dispatcher.Dispatch(new OnSetBoardStateAction(boardState));
        }
    }
}

public record OnSetBoardStateAction(BoardState BoardState);
public record OnPersistBoardStateAction(BoardState BoardState);
public record OnLoadBoardStateAction();