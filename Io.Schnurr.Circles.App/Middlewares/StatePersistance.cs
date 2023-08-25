using System.Reflection;
using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Middlewares;

/// <summary>
/// Saves the state to localStorage after the state has changed.
/// To be persisted the state needs to obtain the <see cref="PersistStateAttribute"/>.
/// </summary>
public sealed class StatePersistance : Fluxor.Middleware, IDisposable
{
    private readonly ILocalStorageService localStorageService;
    private readonly List<IFeature> persistableFeatures = new();

    public StatePersistance(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        foreach (var feature in store.Features.Select(feature => feature.Value))
        {
            var persistAttribute = feature.GetStateType().GetCustomAttribute<PersistStateAttribute>();

            if (persistAttribute != null)
            {
                feature.StateChanged += PersistState;
                persistableFeatures.Add(feature);
            }
        }

        return Task.CompletedTask;
    }

    private async void PersistState(object? sender, EventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        var feature = (IFeature)sender;
        var state = feature.GetState();
        var stateType = feature.GetStateType();

        var statePersistAttribute = stateType.GetCustomAttribute<PersistStateAttribute>();

        if (string.IsNullOrWhiteSpace(statePersistAttribute!.PersistanceName))
        {
            throw new NotImplementedException(nameof(statePersistAttribute.PersistanceName));
        }

        await localStorageService.SetItemAsync(statePersistAttribute!.PersistanceName, state);
    }

    public void Dispose()
    {
        foreach (var feature in persistableFeatures)
        {
            feature.StateChanged -= PersistState;
        }
    }
}