namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// If an action derives from this type, the corresponding state will be persisted to localStorage after dispatching the action.
/// To be persisted the state itself needs to obtain the <see cref="PersistStateAttribute"/>
/// </summary>
public abstract record PersistAfterDispatchAction<T>(T State);