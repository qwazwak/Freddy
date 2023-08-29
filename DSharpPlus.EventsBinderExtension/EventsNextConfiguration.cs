using System;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.EventsBinderExtension;

/// <summary>
/// Represents a configuration for <see cref="EventsNextExtension"/>.
/// </summary>
public sealed class EventsNextConfiguration
{

    /// <summary>
    /// <para>Sets the service provider for this CommandsNext instance.</para>
    /// <para>Objects in this provider are used when instantiating command modules. This allows passing data around without resorting to static members.</para>
    /// <para>Defaults to null.</para>
    /// </summary>
    public required IServiceProvider Services { internal get; set; }
    /// <summary>
    /// Creates a new instance of <see cref="EventsNextConfiguration"/>.
    /// </summary>
    public EventsNextConfiguration() { }

    /// <summary>
    /// Creates a new instance of <see cref="EventsNextConfiguration"/>, copying the properties of another configuration.
    /// </summary>
    /// <param name="other">Configuration the properties of which are to be copied.</param>
    [SetsRequiredMembers]
    public EventsNextConfiguration(EventsNextConfiguration other)
    {
        Services = other.Services;
    }
}
