using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class NavigationBar
{
    [Parameter]
    public EventCallback OnNavigateBack { get; set; }
}
