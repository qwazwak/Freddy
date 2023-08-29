using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsBinderExtension.Tools.Internal;
using DSharpPlus.EventsBinderExtension.Entities;

namespace DSharpPlus.EventsBinderExtension;

/// <summary>
/// This is the class which handles command registration, management, and execution.
/// </summary>
public class EventsNextExtension : BaseExtension, IDisposable
{
    private readonly EventsNextConfiguration config;
    private readonly HashSet<Type> eventHandlersToBind = new();
    private bool IsDisposed;

    /// <summary>
    /// Gets the service provider this CommandsNext module was configured with.
    /// </summary>
    public IServiceProvider Provider => config.Services;

    internal EventsNextExtension(EventsNextConfiguration cfg) => config = new(cfg);

    #region DiscordClient Registration
    /// <summary>
    /// DO NOT USE THIS MANUALLY.
    /// </summary>
    /// <param name="client">DO NOT USE THIS MANUALLY.</param>
    /// <exception cref="InvalidOperationException"/>
    protected override void Setup(DiscordClient client)
    {
        if (Client != null)
            throw new InvalidOperationException("What did I tell you?");

        Client = client;
        EventBindingTools.BindAllHandlers(client, eventHandlersToBind);
    }

    #endregion

    #region Command Registration

    /// <summary>
    /// Binds all commands from a given assembly. The command classes need to be public to be considered for registration.
    /// </summary>
    /// <param name="assembly">Assembly to Bind commands from.</param>
    public void BindEventHandlers(Assembly assembly)
    {
        
        foreach (Type xt in EventsNextUtilities.GetHandlerTypes(assembly))
            BindEventHandler(xt);
    }

    /// <summary>
    /// Binds all commands from a given command class.
    /// </summary>
    /// <typeparam name="T">Class which holds commands to Bind.</typeparam>
    public void BindEventHandler<T>() where T : class, IDiscordEventHandler => EventBindingTools.BindHandler<T>(Client);

    /// <summary>
    /// Binds all commands from a given command class.
    /// </summary>
    /// <param name="t">Type of the class which holds commands to Bind.</param>
    public void BindEventHandler(Type t) => EventBindingTools.BindHandler(this.Client, t);

    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            IsDisposed = true;
        }
    }

    public override void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
