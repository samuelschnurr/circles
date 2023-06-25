using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;

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
    public async Task UpdateState(UpdateStateAction action, IDispatcher dispatcher)
    {
        var newState = action!.state;
        dispatcher.Dispatch(new SetStateAction(newState));
        await localStorageService.SetItemAsync(persistanceName, newState);

        if (action.callbackAfterUpdate != null)
        {
            await action.callbackAfterUpdate.Value.InvokeAsync();
        }
    }

    [EffectMethod(typeof(InitializeStateAction))]
    public async Task InitializeState(IDispatcher dispatcher)
    {
        var storageState = await localStorageService.GetItemAsync<BoardState>(persistanceName);

        if (storageState == null)
        {
            dispatcher.Dispatch(new UpdateStateAction(new BoardState() with { IsTileView = true }));
        }
        else
        {
            dispatcher.Dispatch(new SetStateAction(storageState));
        }
    }
}

public record UpdateStateAction(BoardState state, EventCallback? callbackAfterUpdate = null);
public record InitializeStateAction();