using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class FabButton
{
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public string Icon { get; init; }
}