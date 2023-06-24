using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisement;
public partial class AdvertisementToolBar
{
    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    [Parameter]
    public EventCallback ToggleTileView { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }
}
