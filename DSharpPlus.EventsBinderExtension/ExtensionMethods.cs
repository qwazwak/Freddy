using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DSharpPlus.EventsBinderExtension.Tools.Internal;
using DSharpPlus.EventsBinderExtension.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsBinderExtension;
//
// Summary:
//     Defines various extensions specific to CommandsNext.
public static class ExtensionMethods
{
    //
    // Summary:
    //     Enables CommandsNext module on this DSharpPlus.DiscordClient.
    //
    // Parameters:
    //   client:
    //     Client to enable CommandsNext for.
    //
    //   cfg:
    //     CommandsNext configuration to use.
    //
    // Returns:
    //     Created DSharpPlus.CommandsNext.EventsNextExtension.
    public static void AddEventsNextHandlers(this IServiceCollection services, IEnumerable<Type> types, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        ArgumentNullException.ThrowIfNull(types);
        foreach (Type type in types)
            services.AddEventsNextHandler(type, lifetime);
    }
    public static void AddAllEventsNextHandlers(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient) => services.AddEventsNextHandlers(Assembly.GetExecutingAssembly(), lifetime);
    public static void AddEventsNextHandlers(this IServiceCollection services, Assembly fromAssembly, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        ArgumentNullException.ThrowIfNull(fromAssembly);
        services.AddEventsNextHandlers(EventsNextUtilities.GetHandlerTypes(fromAssembly), lifetime);
    }
    public static void AddEventsNextHandler(this IServiceCollection services, Type implementationType, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        ArgumentNullException.ThrowIfNull(services);
        //var types = EventsNextUtilities.GetInterfaces(implementationType).ToArray();
        //foreach (Type interfaceType in types)
        {
            ServiceDescriptor descriptor = new(/*interfaceType, */implementationType, implementationType, lifetime);
            services.Add(descriptor);
        }
    }

    //
    // Summary:
    //     Enables CommandsNext module on this DSharpPlus.DiscordClient.
    //
    // Parameters:
    //   client:
    //     Client to enable CommandsNext for.
    //
    //   cfg:
    //     CommandsNext configuration to use.
    //
    // Returns:
    //     Created DSharpPlus.CommandsNext.EventsNextExtension.
    public static EventsNextExtension UseEventsNext(this DiscordClient client, EventsNextConfiguration cfg)
    {
        if (client.GetExtension<EventsNextExtension>() != null)
            throw new InvalidOperationException("EventsNext is already enabled for that client.");

        EventsNextExtension EventsNextExtension = new(cfg);
        client.AddExtension(EventsNextExtension);
        return EventsNextExtension;
    }

    //
    // Summary:
    //     Enables CommandsNext module on all shards in this DSharpPlus.DiscordShardedClient.
    //
    // Parameters:
    //   client:
    //     Client to enable CommandsNext for.
    //
    //   cfg:
    //     CommandsNext configuration to use.
    //
    // Returns:
    //     A dictionary of created DSharpPlus.CommandsNext.EventsNextExtension, indexed
    //     by shard id.
    public static async Task<IReadOnlyDictionary<int, EventsNextExtension>> UseEventsNextAsync(this DiscordShardedClient client, EventsNextConfiguration cfg)
    {
        Dictionary<int, EventsNextExtension> modules = new(client.ShardClients.Count);
        await client.InitializeShardsAsync();
        foreach (DiscordClient item in client.ShardClients.Values)
        {
            modules[item.ShardId] = item.GetExtension<EventsNextExtension>() ?? item.UseEventsNext(cfg);
        }

        return new ReadOnlyDictionary<int, EventsNextExtension>(modules);
    }

    //
    // Summary:
    //     Gets the active CommandsNext module for this client.
    //
    // Parameters:
    //   client:
    //     Client to get CommandsNext module from.
    //
    // Returns:
    //     The module, or null if not activated.
    public static EventsNextExtension GetEventsNext(this DiscordClient client) => client.GetExtension<EventsNextExtension>();

    //
    // Summary:
    //     Gets the active CommandsNext modules for all shards in this client.
    //
    // Parameters:
    //   client:
    //     Client to get CommandsNext instances from.
    //
    // Returns:
    //     A dictionary of the modules, indexed by shard id.
    public static async Task<IReadOnlyDictionary<int, EventsNextExtension>> GetEventsNextAsync(this DiscordShardedClient client)
    {
        await client.InitializeShardsAsync();
        Dictionary<int, EventsNextExtension> dictionary = new();
        foreach (DiscordClient item in client.ShardClients.Select<KeyValuePair<int, DiscordClient>, DiscordClient>((KeyValuePair<int, DiscordClient> xkvp) => xkvp.Value))
        {
            dictionary.Add(item.ShardId, item.GetExtension<EventsNextExtension>());
        }

        return new ReadOnlyDictionary<int, EventsNextExtension>(dictionary);
    }

    //
    // Summary:
    //     Binds all commands from a given assembly. The command classes need to be
    //     public to be considered for registration.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    //   assembly:
    //     Assembly to Bind commands from.
    public static void BindHandlers(this IReadOnlyDictionary<int, EventsNextExtension> extensions, Assembly assembly)
    {
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandlers(assembly);
    }

    //
    // Summary:
    //     Binds all commands from a given command class.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    // Type parameters:
    //   T:
    //     Class which holds commands to Bind.
    public static void BindEventHandler<T>(this IReadOnlyDictionary<int, EventsNextExtension> extensions) where T : class, IDiscordEventHandler
    {
        EventsNextUtilities.VerifyHandler(typeof(T));
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler<T>();
    }

    //
    // Summary:
    //     Binds all commands from a given command class.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    //   t:
    //     Type of the class which holds commands to Bind.
    public static void BindEventHandler(this IReadOnlyDictionary<int, EventsNextExtension> extensions, Type t)
    {
        EventsNextUtilities.VerifyHandler(t);
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler(t);
    }
}
