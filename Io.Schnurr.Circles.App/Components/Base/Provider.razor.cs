using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Base;

public partial class Provider
{
    [Parameter]
    public bool IsDarkMode { get; set; }
}
