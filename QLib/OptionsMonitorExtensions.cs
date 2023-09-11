using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace QLib;

public static class OptionsMonitorExtensions
{
    /// <inheritdoc cref="OnChange{TOptions}(IOptionsMonitor{TOptions}, string, Action{TOptions}, StringComparison)"/>
    public static IDisposable? OnChange<TOptions>(this IOptionsMonitor<TOptions> monitor, string key, Action<TOptions> listener)
        => monitor.OnChange(key, listener, StringComparison.InvariantCulture);

    /// <param name="comparison">The way to match <paramref name="key"/> to the named option</param>
    /// <inheritdoc cref="OnChange{TOptions}(IOptionsMonitor{TOptions}, string, Action{TOptions}, IEqualityComparer{string})"/>
    public static IDisposable? OnChange<TOptions>(this IOptionsMonitor<TOptions> monitor, string key, Action<TOptions> listener, StringComparison comparison) => monitor.OnChange(key, listener, StringComparer.FromComparison(comparison));

    /// <summary>
    /// Registers a listener to be called whenever a named <typeparamref name="TOptions"/>, with a name matching <paramref name="key"/>, changes.
    /// </summary>
    /// <param name="key">The option name to invoke <paramref name="listener"/> for.</param>
    /// <inheritdoc cref="Microsoft.Extensions.Options.OptionsMonitorExtensions.OnChange{TOptions}(IOptionsMonitor{TOptions}, Action{TOptions})"/>
    public static IDisposable? OnChange<TOptions>(this IOptionsMonitor<TOptions> monitor, string key, Action<TOptions> listener, IEqualityComparer<string> comparer)
        => monitor.OnChange((o, name) =>
        {
            if (name != null && comparer.Equals(name, key))
                listener(o);
        });
}