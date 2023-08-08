using Fluxor;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Initialize the Fluxor State on initialize by default values or by localStorage.
/// </summary>
public class StateInitialization : Fluxor.Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        dispatcher.Dispatch(new App.InitializeStateAction());
        dispatcher.Dispatch(new Board.InitializeStateAction());
        dispatcher.Dispatch(new Advertisement.InitializeStateAction());

        return Task.CompletedTask;
    }
}
