using Io.Schnurr.Circles.App.Interfaces;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    private bool? IsTileView { get; set; }

    public bool IsLoading() => IsTileView == null;

    protected override async Task OnInitializedAsync()
    {
        IsTileView = false; //GET FROM STATE

        if (IsTileView == null)
        {
            await HandleIsTileViewChanged(false);
        }
    }

    private async Task HandleIsTileViewChanged(bool? value)
    {
        IsTileView = value;
        //GET FROM STATE
    }

    private bool ShowTileView() => IsTileView!.Value;
}
