using Microsoft.AspNetCore.Components.Routing;

namespace Io.Schnurr.Circles.App.Shared;

public partial class NavMenu
{
    protected bool collapseNavMenu = true;

    protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected MenuItem[] menuItems = new MenuItem[] {
        new MenuItem("Board", "", "oi oi-grid-three-up", NavLinkMatch.All),
        new MenuItem("Pins", "pins", "oi oi-pin"),
        new MenuItem("Circles", "circles", "oi oi-target")
    };
}