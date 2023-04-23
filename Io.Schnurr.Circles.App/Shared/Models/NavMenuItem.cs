﻿using Microsoft.AspNetCore.Components.Routing;

namespace Io.Schnurr.Circles.App.Shared.Models;

public class NavMenuItem
{
    public NavMenuItem(string label, string href, string classes, NavLinkMatch match = default)
    {
        this.label = label;
        this.href = href;
        this.classes = classes;
        this.match = match;
    }

    internal readonly string label;
    internal string href;
    internal string classes;
    internal NavLinkMatch match;
}
