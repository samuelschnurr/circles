using Io.Schnurr.Circles.App.Store;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class Drawer
{
    private void ToggleDarkMode()
    {
        Dispatcher.Dispatch(new ToggleDarkModeAction());
    }
}