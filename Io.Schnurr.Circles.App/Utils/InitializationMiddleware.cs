using Fluxor;

namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// Initialize the Fluxor State on initialize by default values or by localStorage.
/// </summary>
public class InitializationMiddleware : Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        dispatcher.Dispatch(new Store.App.InitializeState());
        dispatcher.Dispatch(new Store.Board.InitializeState());

        return Task.CompletedTask;
    }
}
