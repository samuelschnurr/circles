using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class Drawer
{
    private void OnIsDarkModeChanged()
    {
        Dispatcher.Dispatch(new OnIsDarkModeChangedAction());
    }
}