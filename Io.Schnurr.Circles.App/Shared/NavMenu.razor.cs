using Io.Schnurr.Circles.App.Models;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Shared;

public partial class NavMenu
{
    private readonly NavMenuItem[] navMenuItems = new NavMenuItem[] {
        new Models.NavMenuItem("Board", "", Icons.Material.Filled.Dashboard, NavLinkMatch.All),
        new Models.NavMenuItem("Pins", "pins", Icons.Material.Filled.PushPin),
        new Models.NavMenuItem("Circles", "circles", Icons.Material.Filled.BubbleChart)
    };
}