namespace Io.Schnurr.Circles.App.Utils;

/// <summary>
/// When a StateAction is tagged with this attribute, it will be executed on the startup and initialization of Fluxor.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class InitializeOnStartupAttribute : Attribute { }
