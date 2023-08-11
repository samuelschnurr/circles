namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// When a action is tagged with this attribute, it will be executed on the startup initialization of Fluxor.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class InitializeOnStartupAttribute : Attribute { }

/// <summary>
/// When a state is tagged with this attribute, it will be persisted to the localStorage after dispatching an action.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class PersistStateAttribute : Attribute
{
    internal string PersistanceName { get; init; }

    internal static string GetPersistanceName<T>()
    {
        var attribute = GetCustomAttribute(typeof(T), typeof(PersistStateAttribute)) as PersistStateAttribute;

        if (attribute != null)
        {
            return attribute.PersistanceName;
        }

        throw new NotImplementedException(nameof(PersistanceName));
    }
}