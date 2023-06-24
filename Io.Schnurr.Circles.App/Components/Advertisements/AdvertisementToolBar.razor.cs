using Io.Schnurr.Circles.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Components.Advertisements;
public partial class AdvertisementToolBar
{
    [Parameter]
    public EventCallback<string> OnSearch { get; set; }

    [Parameter]
    public EventCallback<SortDirection> OnSortDirectionChanged { get; set; }

    [Parameter]
    public EventCallback ToggleTileView { get; set; }

    [Parameter]
    public bool ShowTileView { get; set; }

    public SortDirection SortDirection
    {
        get => sortDirection;
        set
        {
            sortDirection = value;
            OnSortDirectionChanged.InvokeAsync(value);
        }
    }

    private SortDirection sortDirection = SortDirection.Ascending;
}
