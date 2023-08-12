namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// When a action is tagged with this attribute, it will be executed on the startup initialization of Fluxor.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class InitializeOnStartupAttribute : Attribute { }

/// <summary>
/// When a state is tagged with this attribute, it will be persisted to the localStorage after dispatching an action.
/// To be persisted the executing action needs to obtain the <see cref="PersistAfterDispatchAttribute"/>
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class PersistStateAttribute : Attribute
{
    public string PersistanceName { get; init; }

    internal static string GetPersistanceName<T>()
    {
        var attribute = GetCustomAttribute(typeof(T), typeof(PersistStateAttribute)) as PersistStateAttribute;

        if (attribute == null || string.IsNullOrWhiteSpace(attribute.PersistanceName))
        {
            throw new NotImplementedException(nameof(PersistanceName));
        }

        return attribute.PersistanceName;
    }
}

/// <summary>
/// If a action tagged with this attribute, the corresponding state will be persisted to localStorage after dispatching the action.
/// To be persisted the state itself needs to obtain the <see cref="PersistStateAttribute"/>
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class PersistAfterDispatchAttribute : Attribute { }