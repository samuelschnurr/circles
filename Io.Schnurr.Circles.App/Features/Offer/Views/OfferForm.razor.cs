using Fluxor;
using Io.Schnurr.Circles.App.Features.Offer.Store;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using static Io.Schnurr.Circles.App.Features.Offer.Store.OfferActions;

namespace Io.Schnurr.Circles.App.Features.Offer.Views;

public partial class OfferForm
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private IState<OfferState> OfferState { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    private bool ShowLoadingSpinner => Advertisement == null;

    private Advertisement? Advertisement => OfferState.Value.Items?.SingleOrDefault(i => i.Id == Id) ?? new Advertisement();

    protected override Task OnInitializedAsync()
    {
        if (OfferState.Value.Items == null)
        {
            Dispatcher.Dispatch(new LoadAdvertisementsAction());
        }

        return Task.CompletedTask;
    }

    private void NavigateBack() => NavigationManager.NavigateTo(Routes.Offer.Page);

    private void SetCondition(AdvertisementCondition condition) => model.Condition = condition;
}
