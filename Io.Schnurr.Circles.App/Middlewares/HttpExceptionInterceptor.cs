namespace Io.Schnurr.Circles.App.Middlewares;

internal class HttpExceptionInterceptor : HttpClientHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException hre)
        {
            //TODO: Implement Snackbar
        }

        return response;
    }
}