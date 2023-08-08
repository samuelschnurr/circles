using System.Runtime.Serialization;

namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// If a state derives from this record it will be able to be persisted to local storage.
/// </summary>
public abstract record PersistableState
{
    internal abstract string PersistanceName { get; }

    public static string GetPersistanceName<T>() where T : PersistableState
    {
        var uninitializedObject = ((T)FormatterServices.GetUninitializedObject(typeof(T)));
        var persistanceName = uninitializedObject.PersistanceName;
        return persistanceName;
    }
}

/// <summary>
/// If a action derives from this record it will persist the new state in local storage, if the state itself is persistable. 
/// </summary>
public abstract record PersistAfterDispatchAction<T>(T state);