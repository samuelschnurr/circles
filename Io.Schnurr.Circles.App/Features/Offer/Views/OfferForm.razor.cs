using Fluxor;
using Io.Schnurr.Circles.App.Features.Offer.Store;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using Io.Schnurr.Circles.Shared.Validators;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static Io.Schnurr.Circles.App.Features.Offer.Store.OfferActions;

namespace Io.Schnurr.Circles.App.Features.Offer.Views;

public partial class OfferForm
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private IState<OfferState> OfferState { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Inject]
    private AdvertisementService AdvertisementService { get; set; }

    private MudForm form;

    private readonly AdvertisementValidator advertisementValidator = new();

    private Advertisement Model = new Advertisement(); // TODO: The problem is here. I cant use => to get the modelvalue and need =. Where to init Model from id?
    //private Advertisement Model => OfferState.Value.Items?.SingleOrDefault(i => i.Id == Id) ?? new Advertisement();

    private bool ShowLoadingSpinner => !OfferState.Value.IsReady;

    protected override Task OnInitializedAsync()
    {
        if (OfferState.Value.Items == null)
        {
            Dispatcher.Dispatch(new LoadAdvertisementsAction());
        }

        return Task.CompletedTask;
    }

    private void NavigateBack() => NavigationManager.NavigateTo(Routes.Offer.Page);

    private void SetCondition(AdvertisementCondition condition) => Model.Condition = condition;

    private async Task Submit()
    {
        await form.Validate();

        if (form.IsValid)
        {
            //await AdvertisementService.PostAdvertisement(Model);
        }
    }

    // TODO: Show edit form values when Model exists
    // TODO: Receive, Validate and Store Post in API with fluent
    // TODO: Show Loading when api is loading
}
