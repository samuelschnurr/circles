using Fluxor;
using Io.Schnurr.Circles.App.Features.Offer.Store;
using Io.Schnurr.Circles.App.Services;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Enums;
using Io.Schnurr.Circles.Shared.Models;
using Io.Schnurr.Circles.Shared.TestData;
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

    private MudForm Form { get; set; }

    private readonly AdvertisementValidator advertisementValidator = new();

    private Advertisement? Model;

    private bool ShowLoadingSpinner()
    {
        if (Model != null)
        {
            return false;
        }

        if (Id <= 0)
        {
            Model = new Advertisement() { CreatedBy = TestUserContext.MailAddress };
        }
        else if (OfferState.Value.IsReady)
        {
            Model = OfferState.Value.Items?.SingleOrDefault(i => i.Id == Id);
        }

        return Model == null;
    }

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
        await Form.Validate();

        if (Form.IsValid)
        {
            Dispatcher.Dispatch(new SetOfferStateIsLoadingAction(true));
            await AdvertisementService.PostAdvertisement(Model);
            Dispatcher.Dispatch(new SetOfferStateIsLoadingAction(false));
            NavigateBack();
        }
    }
}
