namespace Io.Schnurr.Circles.App.Features.App.Store;

public abstract class AppActions
{
    public record ToggleDarkModeAction();
    public record ToggleDrawerViaAppBarAction();
    public record ToggleDrawerViaDrawerAction(bool NewValue);
}