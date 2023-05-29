namespace Io.Schnurr.Circles.App.Pages;

public partial class Index
{
    private bool IsTileView { get; set; }

    protected override async Task OnInitializedAsync()
    {
        IsTileView = await LocalStorage.GetItemAsync<bool>(nameof(IsTileView));
    }

    private async Task HandleIsTileViewChanged(bool value)
    {
        IsTileView = value;
        await LocalStorage.SetItemAsync(nameof(IsTileView), value);
    }
}
