using Microsoft.AspNetCore.Components.Web;
using static Io.Schnurr.Circles.App.Features.App.Store.AppActions;

namespace Io.Schnurr.Circles.App.Components.Base;

public sealed partial class MainLayout : IDisposable
{
    private ErrorBoundary? ErrorBoundary { get; set; }

    protected override void OnInitialized()
    {
        // MainLayout cant inherit vom FluxorComponent to rerender automatically on StateChanges beause it inherits vom LayoutComponentBase
        // So manually call the components StateHasChanged, whenever the state of AppState has changed.
        AppState.StateChanged += HandleStateHasChanged;
    }

    protected override void OnParametersSet() => RecoverError();

    private void ToggleDrawerViaAppBar() => Dispatcher.Dispatch(new ToggleDrawerViaAppBarAction());

    private void ToggleDrawerViaDrawer(bool newValue) => Dispatcher.Dispatch(new ToggleDrawerViaDrawerAction(newValue));

    private void ToggleDarkMode() => Dispatcher.Dispatch(new ToggleDarkModeAction());

    private void HandleStateHasChanged(object? sender, EventArgs e) => InvokeAsync(StateHasChanged);

    public void Dispose() => AppState.StateChanged -= HandleStateHasChanged;

    private void RecoverError() => ErrorBoundary?.Recover();
}
