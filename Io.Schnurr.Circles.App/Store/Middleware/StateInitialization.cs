using System.Reflection;
using System.Text.Json;
using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Utils;

namespace Io.Schnurr.Circles.App.Store.Middleware;

/// <summary>
/// Initializes the state with values from localStorage.
/// To be initialized from localStorage the state needs to obtain the <see cref="PersistStateAttribute"/>.
/// </summary>
public class StateInitialization : Fluxor.Middleware
{
    private readonly ILocalStorageService localStorageService;

    public StateInitialization(ILocalStorageService localStorageService)
    {
        this.localStorageService = localStorageService;
    }

    public override async Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        foreach (var feature in store.Features.Select(feature => feature.Value))
        {
            var persistAttribute = feature.GetStateType().GetCustomAttribute<PersistStateAttribute>();

            if (persistAttribute == null)
            {
                continue;
            }

            var storageStateJson = await localStorageService.GetItemAsStringAsync(persistAttribute.PersistanceName);
            var featureState = feature.GetStateType();

            if (string.IsNullOrWhiteSpace(storageStateJson))
            {
                var defaultState = Activator.CreateInstance(featureState);
                var defaultJsonState = JsonSerializer.Serialize(defaultState);
                await localStorageService.SetItemAsStringAsync(persistAttribute.PersistanceName, defaultJsonState);
            }
            else
            {
                var storageState = JsonSerializer.Deserialize(storageStateJson, featureState);
                feature.RestoreState(storageState);
            }
        }
    }
}
