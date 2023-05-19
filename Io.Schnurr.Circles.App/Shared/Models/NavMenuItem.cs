using Microsoft.AspNetCore.Components.Routing;

namespace Io.Schnurr.Circles.App.Shared.Models;

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
    internal string href;
    internal string icon;
    internal NavLinkMatch match;
}
