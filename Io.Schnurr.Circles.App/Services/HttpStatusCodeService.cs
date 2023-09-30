using MudBlazor;

namespace Io.Schnurr.Circles.App.Services;

internal class HttpStatusCodeService : DelegatingHandler
{
    private readonly ISnackbar snackbar;

    public HttpStatusCodeService(ISnackbar snackbar)
    {
        this.snackbar = snackbar;
        this.snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
        this.snackbar.Configuration.HideTransitionDuration = 500;
        this.snackbar.Configuration.ShowTransitionDuration = 500;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            snackbar.Add("Success!", Severity.Success);
        }
        else
        {
            snackbar.Add("Error!", Severity.Error);
        }

        return response;
    }
}