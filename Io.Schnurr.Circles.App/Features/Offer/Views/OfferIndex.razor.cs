using Fluxor;
using Io.Schnurr.Circles.App.Features.Offer.Store;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using static Io.Schnurr.Circles.App.Features.Offer.Store.OfferActions;

namespace Io.Schnurr.Circles.App.Features.Offer.Views;

public partial class OfferIndex
{
    [Inject]
    private IState<OfferState> OfferState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<Advertisement> Data => OfferState.Value.Items;

    public bool ShowLoadingSpinner => !OfferState.Value.IsReady || Data == null;

    protected override async Task OnInitializedAsync()
    {
        Dispatcher.Dispatch(new LoadAdvertisementsAction());
        await Task.CompletedTask;
    }

    private void NavigateToOfferForm(int? id = null) => NavigationManager.NavigateTo(Routes.Offer.GetFormPath(id));
}
