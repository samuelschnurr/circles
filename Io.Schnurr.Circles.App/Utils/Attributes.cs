namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// When a state is tagged with this attribute, it will be persisted to the localStorage after state has changed.
/// Also the state will be loaded from localStorage on initialization.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
internal class PersistStateAttribute : Attribute
{
    internal string PersistanceName { get; }

    public PersistStateAttribute(string persistanceName)
    {
        this.PersistanceName = persistanceName;
    }

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