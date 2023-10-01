using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Layout;

public partial class Drawer
{
    [Parameter]
    public EventCallback OnToggleDarkMode { get; set; }

    [Parameter]
    public EventCallback<bool> OnToggleDrawer { get; set; }

    [Parameter]
    public bool IsDrawerOpen { get; set; }

    [Parameter]
    public bool IsDarkMode { get; set; }
}