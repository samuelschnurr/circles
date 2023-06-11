﻿using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class AppBar
{
    private void ToggleDrawer()
    {
        Dispatcher.Dispatch(new UpdateStateAction(AppState.Value with { IsDrawerOpen = !AppState.Value.IsDrawerOpen }));
    }
}