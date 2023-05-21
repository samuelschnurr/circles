using Io.Schnurr.Circles.App.Models;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class NavMenu
{
    private readonly NavMenuItem[] navMenuItems = new NavMenuItem[] {
        new NavMenuItem("Board", "", Icons.Material.Filled.Dashboard, NavLinkMatch.All),
        new NavMenuItem("Pins", "pins", Icons.Material.Filled.PushPin),
        new NavMenuItem("Circles", "circles", Icons.Material.Filled.BubbleChart)
    };
}