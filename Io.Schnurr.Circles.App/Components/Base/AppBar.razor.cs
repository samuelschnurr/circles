﻿using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class AppBar
{
    private void OnIsDrawerOpenChanged()
    {
        Dispatcher.Dispatch(new SetState(AppState.Value with { IsDrawerOpen = !AppState.Value.IsDrawerOpen }));
    }
}