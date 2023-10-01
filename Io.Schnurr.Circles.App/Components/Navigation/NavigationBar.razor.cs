using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Navigation;

public partial class NavigationBar
{
    [Parameter]
    public EventCallback OnNavigateBack { get; set; }
}
