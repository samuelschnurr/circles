using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Io.Schnurr.Circles.App.Components.UserInterface;

public partial class IconButton
{
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public Size Size { get; set; }

    [Parameter]
    public string Icon { get; init; }

    [Parameter]
    public string Title { get; init; }
}
