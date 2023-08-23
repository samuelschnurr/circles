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
            var storageStateExists = !string.IsNullOrWhiteSpace(storageStateJson);

            if (storageStateExists)
            {
                RestoreStateFromStorage(feature, storageStateJson);
            }
            else
            {
                await RestoreStateFromDefault(feature, persistAttribute.PersistanceName);
            }
        }
    }

    private async Task RestoreStateFromDefault(IFeature feature, string persistanceName)
    {
        var featureState = feature.GetStateType();
        var defaultState = Activator.CreateInstance(featureState);
        SetIsInitializedTrue(defaultState);
        var defaultJsonState = JsonSerializer.Serialize(defaultState);

        // Restore state, because initial state has IsInitialized = false
        feature.RestoreState(defaultState);

        await localStorageService.SetItemAsStringAsync(persistanceName, defaultJsonState);
    }

    private static void RestoreStateFromStorage(IFeature feature, string state)
    {
        var featureState = feature.GetStateType();
        var storageState = JsonSerializer.Deserialize(state, featureState);
        SetIsInitializedTrue(storageState);
        feature.RestoreState(storageState);
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

#pragma warning disable S3011
        // Reflection should not be used to increase accessibility of classes, methods, or fields
        // Anyway its used here, because the properties should be internal to not be recognized by fluxor library, but must be seen in initialization step
        var isInitializedProperty = stateType.GetProperty(nameof(BaseState.IsInitialized), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
#pragma warning restore S3011

        if (isInitializedProperty == null)
        {
            return;
        }

        isInitializedProperty.SetValue(state, true);
    }
}