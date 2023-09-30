using Fluxor;
using Io.Schnurr.Circles.App.Features.Offer.Store;
using Microsoft.AspNetCore.Components;

namespace Io.Schnurr.Circles.App.Features.Offer.Views;

public partial class OfferIndex
{
    [Inject]
    private IState<OfferState> OfferState { get; set; }

    public bool ShowLoadingSpinner => !OfferState.Value.IsInitialized;
}