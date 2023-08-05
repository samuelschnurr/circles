using Io.Schnurr.Circles.App.Store.App;

namespace Io.Schnurr.Circles.App.Components.Base;

public sealed partial class MainLayout : IDisposable
{
    protected override void OnInitialized()
    {
        // MainLayout cant inherit vom FluxorComponent to rerender automatically on StateChanges beause it inherits vom LayoutComponentBase
        // So manually call the components StateHasChanged, whenever the state of AppState has changed.
        AppState.StateChanged += HandleStateHasChanged;
    }

    private void ToggleDrawerViaAppBar()
    {
        Dispatcher.Dispatch(new UpdateStateAction(AppState.Value with { IsDrawerOpen = !AppState.Value.IsDrawerOpen }));
    }

    private void ToggleDrawerViaDrawer(bool newValue)
    {
        // Handle toggling drawer correctly in mobile view
        // Close Overlay when a click outside is recognized
        var currentValue = AppState.Value.IsDrawerOpen;

        if (newValue != currentValue)
        {
            Dispatcher.Dispatch(new UpdateStateAction(AppState.Value with { IsDrawerOpen = !AppState.Value.IsDrawerOpen }));
        }
    }

    private void ToggleDarkMode()
    {
        Dispatcher.Dispatch(new UpdateStateAction(AppState.Value with { IsDarkMode = !AppState.Value.IsDarkMode }));
    }

    private void HandleStateHasChanged(object? sender, EventArgs e) => StateHasChanged();

    public void Dispose()
    {
        AppState.StateChanged -= HandleStateHasChanged;
    }
}
