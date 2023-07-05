using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Core;

public partial class Tile
{
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public string SubTitleLeft { get; set; }

    [Parameter]
    public string SubTitleRight { get; set; }

    [Parameter]
    public string Image { get; set; }
}
