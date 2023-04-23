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

    protected Models.NavMenuItem[] navMenuItems = new Models.NavMenuItem[] {
        new Models.NavMenuItem("Board", "", "oi oi-grid-three-up", NavLinkMatch.All),
        new Models.NavMenuItem("Pins", "pins", "oi oi-pin"),
        new Models.NavMenuItem("Circles", "circles", "oi oi-target")
    };
}