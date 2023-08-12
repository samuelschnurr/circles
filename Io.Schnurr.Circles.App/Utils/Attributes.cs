namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// When a action is tagged with this attribute, it will be executed on the startup initialization of Fluxor.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class InitializeOnStartupAttribute : Attribute { }

/// <summary>
/// When a state is tagged with this attribute, it will be persisted to the localStorage after state has changed.
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