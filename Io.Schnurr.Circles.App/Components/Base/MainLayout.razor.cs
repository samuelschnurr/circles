using Io.Schnurr.Circles.App.Features.App.Store;

namespace Io.Schnurr.Circles.App.Components.Base;

public sealed partial class MainLayout : IDisposable
{
    protected override void OnInitialized()
    {
        // MainLayout cant inherit vom FluxorComponent to rerender automatically on StateChanges beause it inherits vom LayoutComponentBase
        // So manually call the components StateHasChanged, whenever the state of AppState has changed.
        AppState.StateChanged += HandleStateHasChanged;
    }

    private void ToggleDrawerViaAppBar() => Dispatcher.Dispatch(new ToggleDrawerViaAppBarAction());

    private void ToggleDrawerViaDrawer(bool newValue) => Dispatcher.Dispatch(new ToggleDrawerViaDrawerAction(newValue));

    private void ToggleDarkMode() => Dispatcher.Dispatch(new ToggleDarkModeAction());

    private void HandleStateHasChanged(object? sender, EventArgs e) => InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        AppState.StateChanged -= HandleStateHasChanged;
    }
}
