using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class Drawer
{
    private void OnIsDarkModeChanged()
    {
        Dispatcher.Dispatch(new OnIsDarkModeChangedAction());
        Dispatcher.Dispatch(new OnPersistAppStateAction());
    }

    private void HandleOverlayClick(bool newValue)
    {
        // Handle toggling drawer correctly in mobile view
        // Close Overlay when a click outside is recognized
        var currentValue = AppState.Value.IsDrawerOpen;
        if (newValue != currentValue)
        {
            Dispatcher.Dispatch(new OnIsDrawerOpenChangedAction());
        }
    }
}