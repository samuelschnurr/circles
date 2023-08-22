namespace Io.Schnurr.Circles.App.Store.Base;

/// <summary>
/// Base State which should be inherited by all other states which are marked with [FeatureState].
/// </summary>
public abstract record BaseState
{
    public bool IsInitialized { get; init; }
    public bool IsLoading { get; init; }
}