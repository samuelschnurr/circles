namespace Io.Schnurr.Circles.App.Store.Base;

/// <summary>
/// Base State which should be inherited by all other states which are marked with [FeatureState].
/// </summary>
public abstract record BaseState
{
    internal bool IsInitialized { get; init; }
    internal bool IsLoading { get; init; }
}