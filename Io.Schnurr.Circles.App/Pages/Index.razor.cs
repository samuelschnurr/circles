using Io.Schnurr.Circles.App.Interfaces;

namespace Io.Schnurr.Circles.App.Pages;

public partial class Index : ILoadingComponent
{
    private bool? IsTileView { get; set; }

    public bool IsLoading() => IsTileView == null;

    protected override async Task OnInitializedAsync()
    {
        IsTileView = await LocalStorage.GetItemAsync<bool?>(nameof(IsTileView));

        if (IsTileView == null)
        {
            await HandleIsTileViewChanged(false);
        }
    }

    private async Task HandleIsTileViewChanged(bool? value)
    {
        IsTileView = value;
        await LocalStorage.SetItemAsync(nameof(IsTileView), value);
    }

    private bool ShowTileView() => IsTileView!.Value;
}
