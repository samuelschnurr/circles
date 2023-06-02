using Io.Schnurr.Circles.App.Store;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class AppBar
{
    private void ToggleDrawer()
    {
        Dispatcher.Dispatch(new ToggleDrawerAction());
    }
}