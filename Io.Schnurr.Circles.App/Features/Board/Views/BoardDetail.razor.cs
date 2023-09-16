using Fluxor;
using Io.Schnurr.Circles.App.Features.Board.Store;
using Io.Schnurr.Circles.App.Utils;
using Io.Schnurr.Circles.Shared.Models;
using Microsoft.AspNetCore.Components;
using static Io.Schnurr.Circles.App.Features.Board.Store.BoardActions;

namespace Io.Schnurr.Circles.App.Features.Board.Views;

public partial class BoardDetail
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    private IState<BoardState> BoardState { get; set; }

    [Inject]
    NavigationManager NavigationManager { get; set; }

    private bool ShowLoadingSpinner => Advertisement == null;

    private Advertisement? Advertisement => BoardState.Value.Items?.Single(i => i.Id == Id);

    private string MailToLink => Advertisement == null ? string.Empty : $"mailto:{Advertisement.CreatedBy}?subject=Request for your product no. {Advertisement.Id}";

    protected override Task OnInitializedAsync()
    {
        if (BoardState.Value.Items == null)
        {
            Dispatcher.Dispatch(new LoadAdvertisementsAction());
        }

        return Task.CompletedTask;
    }

    private void NavigateBack() => NavigationManager.NavigateTo(Routes.Board.Page);
}
