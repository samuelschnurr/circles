using System.Reflection;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Executes all FluxorStateActions which contain the <see cref="InitializeOnStartupAttribute"/>.
/// </summary>
public class StateInitialization : Fluxor.Middleware
{
    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var methodsWithAttribute = assembly.GetTypes().Where(t => t.GetCustomAttribute<InitializeOnStartupAttribute>() != null);

        foreach (var method in methodsWithAttribute)
        {
            var initializationMethod = Activator.CreateInstance(method);
            dispatcher.Dispatch(initializationMethod);
        }

        return Task.CompletedTask;
    }
}
