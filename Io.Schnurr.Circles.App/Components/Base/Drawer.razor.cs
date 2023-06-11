﻿using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class Drawer
{
    private void OnIsDarkModeChanged()
    {
        Dispatcher.Dispatch(new SetState(AppState.Value with { IsDarkMode = !AppState.Value.IsDarkMode }));
        Dispatcher.Dispatch(new PersistState());
    }

    private void HandleOverlayClick(bool newValue)
    {
        // Handle toggling drawer correctly in mobile view
        // Close Overlay when a click outside is recognized
        var currentValue = AppState.Value.IsDrawerOpen;
        if (newValue != currentValue)
        {
            Dispatcher.Dispatch(new SetState(AppState.Value with { IsDrawerOpen = !AppState.Value.IsDrawerOpen }));
        }
    }
}