using Fluxor;
using Io.Schnurr.Circles.App.Store.App;
using Io.Schnurr.Circles.App.Store.Board;

namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// Initialize the Fluxor State on initialize by default values or by localStorage.
/// </summary>
public class InitializationMiddleware : Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        dispatcher.Dispatch(new OnInitializeAppStateAction());
        dispatcher.Dispatch(new InitializeBoardState());

        return Task.CompletedTask;
    }
}
