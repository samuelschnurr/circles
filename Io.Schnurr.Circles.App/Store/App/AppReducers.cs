﻿using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod(typeof(OnIsDrawerOpenChangedAction))]
    public static AppState HandleIsDrawerOpenChangedAction(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };

    [ReducerMethod(typeof(OnIsDarkModeChangedAction))]
    public static AppState HandleIsDarkModeChangedAction(AppState state) => state with { IsDarkMode = !state.IsDarkMode };

    [ReducerMethod]
    public static AppState HandleSetAppState(AppState state, OnSetAppStateAction action) => action.AppState;

    [ReducerMethod(typeof(OnInitializeAppStateAction))]
    public static AppState HandleInitializeAppStateAction(AppState state)
    {
        return new AppState()
        {
            IsDarkMode = false,
            IsDrawerOpen = true
        };
    }
}

public class OnIsDrawerOpenChangedAction { }
public class OnIsDarkModeChangedAction { }
public class OnInitializeAppStateAction { }