using Fluxor;

namespace Io.Schnurr.Circles.App.Store.App;

public static class AppReducer
{
    [ReducerMethod(typeof(ToggleDarkModeAction))]
    public static AppState ToggleDarkMode(AppState state) => state with { IsDarkMode = !state.IsDarkMode };

    [ReducerMethod(typeof(ToggleDrawerViaAppBarAction))]
    public static AppState ToggleDrawerViaAppBar(AppState state) => state with { IsDrawerOpen = !state.IsDrawerOpen };

    [ReducerMethod]
    public static AppState ToggleDrawerViaDrawer(AppState state, ToggleDrawerViaDrawerAction action)
    {
        // Handle toggling drawer correctly in mobile view
        // Close Overlay when a click outside is recognized
        var currentValue = state.IsDrawerOpen;

        if (action.NewValue != currentValue)
        {
            return state with { IsDrawerOpen = !state.IsDrawerOpen };
        }

        return state;
    }

    [ReducerMethod(typeof(SetDefaultStateAction))]
    public static AppState SetDefaultState(AppState state) => new();

    [ReducerMethod]
    public static AppState SetStateFromLocalStorage(AppState state, SetStateFromLocalStorageAction action) => action.State;
}

public record ToggleDarkModeAction();
public record ToggleDrawerViaAppBarAction();
public record ToggleDrawerViaDrawerAction(bool NewValue);
public record SetDefaultStateAction();
public record SetStateFromLocalStorageAction(AppState State);