using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace QLib;

[DebuggerTypeProxy(typeof(ResettableLazyDebugView<>))]
[DebuggerDisplay("ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}")]
public class ResettableLazy<T>
{
    private Func<T> valueFactory;
    private Lazy<T> core;

    public bool IsValueCreated => core.IsValueCreated;
    public T Value
    {
        get => core.Value;
        set => core = new(value);
    }
    public Func<T> ValueFactory { set => core = new(valueFactory = value, Mode); }

    public LazyThreadSafetyMode Mode { get; }

    public ResettableLazy(Func<T> valueFactory, LazyThreadSafetyMode mode = LazyThreadSafetyMode.ExecutionAndPublication)
    {
        this.valueFactory = valueFactory;
        Mode = mode;
        core = new(this.valueFactory, Mode);
    }

    public ResettableLazy(Func<T> valueFactory, bool isThreadSafe) : this(valueFactory, isThreadSafe ? LazyThreadSafetyMode.ExecutionAndPublication : LazyThreadSafetyMode.None) { }

    public void Reset()
    {
        if (core.IsValueCreated)
            core = new(valueFactory, Mode);
    }

    private static PropertyInfo IsValueFaultedInfo => typeof(Lazy<T>).GetProperty("IsValueFaulted", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)!;
    internal bool IsValueFaulted => (bool)IsValueFaultedInfo.GetValue(core)!;
}

/// <summary>A debugger view of the Lazy&lt;T&gt; to surface additional debugging properties and
/// to ensure that the Lazy&lt;T&gt; does not become initialized if it was not already.</summary>
/// <remarks>Constructs a new debugger view object for the provided Lazy object.</remarks>
/// <param name="lazy">A Lazy object to browse in the debugger.</param>
internal sealed class ResettableLazyDebugView<T>
{
    // The Lazy object being viewed.
    private readonly ResettableLazy<T> _resetLazy;
    public ResettableLazyDebugView(ResettableLazy<T> _resetLazy) => this._resetLazy = _resetLazy;
    /// <summary>Returns whether the Lazy object is initialized or not.</summary>
    public bool IsValueCreated => _resetLazy.IsValueCreated;

    /// <summary>Returns the value of the Lazy object.</summary>
    public T? Value => _resetLazy.IsValueCreated ? _resetLazy.Value : default;

    /// <summary>Returns the execution mode of the Lazy object</summary>
    public LazyThreadSafetyMode? Mode => _resetLazy.Mode;

    /// <summary>Returns the execution mode of the Lazy object</summary>
    public bool IsValueFaulted => _resetLazy.IsValueFaulted;
}
