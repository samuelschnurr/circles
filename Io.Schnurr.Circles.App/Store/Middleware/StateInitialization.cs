using System.Reflection;
using System.Text.Json;
using Blazored.LocalStorage;
using Fluxor;
using Io.Schnurr.Circles.App.Store.Base;
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
                SetIsInitializedTrue(defaultState);
                var defaultJsonState = JsonSerializer.Serialize(defaultState);
                // Restore state, because initial state has IsInitialized = false
                feature.RestoreState(defaultState);
                await localStorageService.SetItemAsStringAsync(persistAttribute.PersistanceName, defaultJsonState);
            }
            else
            {
                var storageState = JsonSerializer.Deserialize(storageStateJson, featureState);
                SetIsInitializedTrue(storageState);
                feature.RestoreState(storageState);
            }
        }
    }

    private static void SetIsInitializedTrue(object? state)
    {
        if (state == null)
        {
            throw new ArgumentNullException(nameof(state));
        }

        var stateType = state.GetType();

        if (stateType == null || !stateType.IsSubclassOf(typeof(BaseState)))
        {
            return;
        }

        var isInitializedProperty = stateType.GetProperty(nameof(BaseState.IsInitialized));

        if (isInitializedProperty == null)
        {
            return;
        }

        isInitializedProperty.SetValue(state, true);
    }
}