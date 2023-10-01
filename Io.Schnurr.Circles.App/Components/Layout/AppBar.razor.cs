using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Layout;

public partial class AppBar
{
    [Parameter]
    public EventCallback OnToggleDrawer { get; set; }
}