using Microsoft.AspNetCore.Components.Routing;

namespace Io.Schnurr.Circles.App.Models;

public class NavMenuItem
{
    public NavMenuItem(string label, string href, string icon, NavLinkMatch match = default)
    {
        this.label = label;
        this.href = href;
        this.icon = icon;
        this.match = match;
    }

    internal readonly string label;
    internal readonly string href;
    internal readonly string icon;
    internal readonly NavLinkMatch match;
}
