using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class NavMenu
{
    private readonly (string label, string href, string icon, NavLinkMatch match)[] navMenuItems =
    {
        ("Board", "", Icons.Material.Filled.Dashboard, NavLinkMatch.All),
        ("Pins", "pins", Icons.Material.Filled.PushPin, default(NavLinkMatch)),
        ("Circles", "circles", Icons.Material.Filled.BubbleChart, default(NavLinkMatch))
    };
}