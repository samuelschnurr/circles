﻿using Blazored.LocalStorage;
using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public class AppEffects
{
    private readonly ILocalStorageService localStorageService;
    private const string persistanceName = "circles-app-settings";

    public AppEffects(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    [EffectMethod]
    public async Task PersistState(OnPersistAppStateAction action, IDispatcher dispatcher)
    {
        await localStorageService.SetItemAsync(persistanceName, action.AppState);
    }

    [EffectMethod(typeof(OnSetAppStateAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        var counterState = await localStorageService.GetItemAsync<AppState>(persistanceName);

        if (counterState != null)
        {
            dispatcher.Dispatch(new OnSetAppStateAction(counterState));
        }
    }
}

public record OnSetAppStateAction(AppState AppState);
public record OnPersistAppStateAction(AppState AppState);
public record OnLoadAppStateAction();