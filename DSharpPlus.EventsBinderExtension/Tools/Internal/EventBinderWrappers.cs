#define WrapCore
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.EventArgs;
using System.Diagnostics;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventsBinderExtension.Entities;
using System.Threading.Tasks;

namespace DSharpPlus.EventsBinderExtension.Tools.Internal;

internal static partial class EventBinderWrappers
{
#if WrapCore
    public static AsyncEventHandler<DiscordClient, TArgs> WrapCore<THandler, TInterface, TArgs>(Func<TInterface, DiscordClient, TArgs, Task> invokeFactory)
        where THandler : class, TInterface
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
        => WrapCore(typeof(THandler), invokeFactory);

    public static AsyncEventHandler<DiscordClient, TArgs> WrapCore<TInterface, TArgs>(Type handler, Func<TInterface, DiscordClient, TArgs, Task> invokeFactory)
        where TInterface : IDiscordEventHandler<TArgs>
        where TArgs : DiscordEventArgs
    {
        Debug.Assert(handler.IsAssignableTo(typeof(TInterface)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            TInterface instance = (TInterface)scope.ServiceProvider.GetRequiredService(handler);
            await invokeFactory(instance, client, args);
        };
    }
#endif
}
internal static partial class EventBinderWrappers
{
    public static AsyncEventHandler<DiscordClient, SocketEventArgs> WrapSocketOpened<THandler>() where THandler : class, ISocketOpenedEventHandler
=> WrapSocketOpened(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, SocketEventArgs> WrapSocketOpened(Type handler)
#if WrapCore
        => WrapCore<ISocketOpenedEventHandler, SocketEventArgs>(handler, (instance, client, args) => instance.OnSocketOpened(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(ISocketOpenedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketOpenedEventHandler instance = (ISocketOpenedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSocketOpened(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, SocketCloseEventArgs> WrapSocketClosed<THandler>() where THandler : class, ISocketClosedEventHandler
=> WrapSocketClosed(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, SocketCloseEventArgs> WrapSocketClosed(Type handler)
#if WrapCore
        => WrapCore<ISocketClosedEventHandler, SocketCloseEventArgs>(handler, (instance, client, args) => instance.OnSocketClosed(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(ISocketClosedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ISocketClosedEventHandler instance = (ISocketClosedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnSocketClosed(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ReadyEventArgs> WrapResumed<THandler>() where THandler : class, IResumedEventHandler
=> WrapResumed(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ReadyEventArgs> WrapResumed(Type handler)
#if WrapCore
        => WrapCore<IResumedEventHandler, ReadyEventArgs>(handler, (instance, client, args) => instance.OnResumed(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IResumedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IResumedEventHandler instance = (IResumedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnResumed(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, HeartbeatEventArgs> WrapHeartbeated<THandler>() where THandler : class, IHeartbeatEventHandler
=> WrapHeartbeated(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, HeartbeatEventArgs> WrapHeartbeated(Type handler)
#if WrapCore
        => WrapCore<IHeartbeatEventHandler, HeartbeatEventArgs>(handler, (instance, client, args) => instance.OnHeartbeat(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IHeartbeatEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IHeartbeatEventHandler instance = (IHeartbeatEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnHeartbeat(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> WrapOnChannelCreate<THandler>() where THandler : class, IChannelCreatedEventHandler
=> WrapOnChannelCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ChannelCreateEventArgs> WrapOnChannelCreate(Type handler)
#if WrapCore
        => WrapCore<IChannelCreatedEventHandler, ChannelCreateEventArgs>(handler, (instance, client, args) => instance.OnChannelCreated(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IChannelCreatedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelCreatedEventHandler instance = (IChannelCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelCreated(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ReadyEventArgs> WrapReady<THandler>() where THandler : class, IReadyEventHandler
=> WrapReady(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ReadyEventArgs> WrapReady(Type handler)
#if WrapCore
        => WrapCore<IReadyEventHandler, ReadyEventArgs>(handler, (instance, client, args) => instance.OnReady(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IReadyEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IReadyEventHandler instance = (IReadyEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnReady(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ZombiedEventArgs> WrapZombied<THandler>() where THandler : class, IZombiedEventHandler
=> WrapZombied(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ZombiedEventArgs> WrapZombied(Type handler)
#if WrapCore
        => WrapCore<IZombiedEventHandler, ZombiedEventArgs>(handler, (instance, client, args) => instance.OnZombied(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IZombiedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IZombiedEventHandler instance = (IZombiedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnZombied(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> WrapChannelUpdate<THandler>() where THandler : class, IChannelUpdateEventHandler
=> WrapChannelUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ChannelUpdateEventArgs> WrapChannelUpdate(Type handler)
#if WrapCore
        => WrapCore<IChannelUpdateEventHandler, ChannelUpdateEventArgs>(handler, (instance, client, args) => instance.OnChannelUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IChannelUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelUpdateEventHandler instance = (IChannelUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> WrapChannelDelete<THandler>() where THandler : class, IChannelDeleteEventHandler
=> WrapChannelDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ChannelDeleteEventArgs> WrapChannelDelete(Type handler)
#if WrapCore
        => WrapCore<IChannelDeleteEventHandler, ChannelDeleteEventArgs>(handler, (instance, client, args) => instance.OnChannelDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IChannelDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelDeleteEventHandler instance = (IChannelDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> WrapDmChannelDelete<THandler>() where THandler : class, IDmChannelDeleteEventHandler
=> WrapDmChannelDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, DmChannelDeleteEventArgs> WrapDmChannelDelete(Type handler)
#if WrapCore
        => WrapCore<IDmChannelDeleteEventHandler, DmChannelDeleteEventArgs>(handler, (instance, client, args) => instance.OnDmChannelDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IDmChannelDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IDmChannelDeleteEventHandler instance = (IDmChannelDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnDmChannelDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> WrapChannelPinsUpdate<THandler>() where THandler : class, IChannelPinsUpdateEventHandler
=> WrapChannelPinsUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ChannelPinsUpdateEventArgs> WrapChannelPinsUpdate(Type handler)
#if WrapCore
        => WrapCore<IChannelPinsUpdateEventHandler, ChannelPinsUpdateEventArgs>(handler, (instance, client, args) => instance.OnChannelPinsUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IChannelPinsUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IChannelPinsUpdateEventHandler instance = (IChannelPinsUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnChannelPinsUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildCreate<THandler>() where THandler : class, IGuildCreateEventHandler
=> WrapGuildCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildCreateEventArgs> WrapGuildCreate(Type handler)
#if WrapCore
        => WrapCore<IGuildCreateEventHandler, GuildCreateEventArgs>(handler, (instance, client, args) => instance.OnGuildCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildCreateEventHandler instance = (IGuildCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> WrapGuildUpdate<THandler>() where THandler : class, IGuildUpdateEventHandler
=> WrapGuildUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildUpdateEventArgs> WrapGuildUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildUpdateEventHandler, GuildUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildUpdateEventHandler instance = (IGuildUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildDelete<THandler>() where THandler : class, IGuildDeleteEventHandler
=> WrapGuildDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildDeleteEventArgs> WrapGuildDelete(Type handler)
#if WrapCore
        => WrapCore<IGuildDeleteEventHandler, GuildDeleteEventArgs>(handler, (instance, client, args) => instance.OnGuildDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDeleteEventHandler instance = (IGuildDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> WrapGuildDownloadCompleted<THandler>() where THandler : class, IGuildDownloadCompletedEventHandler
=> WrapGuildDownloadCompleted(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildDownloadCompletedEventArgs> WrapGuildDownloadCompleted(Type handler)
#if WrapCore
        => WrapCore<IGuildDownloadCompletedEventHandler, GuildDownloadCompletedEventArgs>(handler, (instance, client, args) => instance.OnGuildDownloadCompleted(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildDownloadCompletedEventHandler instance = (IGuildDownloadCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildDownloadCompleted(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> WrapGuildEmojisUpdate<THandler>() where THandler : class, IGuildEmojisUpdateEventHandler
=> WrapGuildEmojisUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildEmojisUpdateEventArgs> WrapGuildEmojisUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildEmojisUpdateEventHandler, GuildEmojisUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildEmojisUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildEmojisUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildEmojisUpdateEventHandler instance = (IGuildEmojisUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildEmojisUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> WrapGuildStickersUpdate<THandler>() where THandler : class, IGuildStickersUpdateEventHandler
=> WrapGuildStickersUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildStickersUpdateEventArgs> WrapGuildStickersUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildStickersUpdateEventHandler, GuildStickersUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildStickersUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildStickersUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildStickersUpdateEventHandler instance = (IGuildStickersUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildStickersUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> WrapGuildIntegrationsUpdate<THandler>() where THandler : class, IGuildIntegrationsUpdateEventHandler
=> WrapGuildIntegrationsUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildIntegrationsUpdateEventArgs> WrapGuildIntegrationsUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildIntegrationsUpdateEventHandler, GuildIntegrationsUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildIntegrationsUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildIntegrationsUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildIntegrationsUpdateEventHandler instance = (IGuildIntegrationsUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildIntegrationsUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> WrapScheduledGuildEventCreate<THandler>() where THandler : class, IScheduledGuildEventCreateEventHandler
=> WrapScheduledGuildEventCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCreateEventArgs> WrapScheduledGuildEventCreate(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventCreateEventHandler, ScheduledGuildEventCreateEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCreateEventHandler instance = (IScheduledGuildEventCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> WrapScheduledGuildEventUpdate<THandler>() where THandler : class, IScheduledGuildEventUpdateEventHandler
=> WrapScheduledGuildEventUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUpdateEventArgs> WrapScheduledGuildEventUpdate(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventUpdateEventHandler, ScheduledGuildEventUpdateEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUpdateEventHandler instance = (IScheduledGuildEventUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> WrapScheduledGuildEventDelete<THandler>() where THandler : class, IScheduledGuildEventDeleteEventHandler
=> WrapScheduledGuildEventDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventDeleteEventArgs> WrapScheduledGuildEventDelete(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventDeleteEventHandler, ScheduledGuildEventDeleteEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventDeleteEventHandler instance = (IScheduledGuildEventDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> WrapScheduledGuildEventCompleted<THandler>() where THandler : class, IScheduledGuildEventCompletedEventHandler
=> WrapScheduledGuildEventCompleted(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventCompletedEventArgs> WrapScheduledGuildEventCompleted(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventCompletedEventHandler, ScheduledGuildEventCompletedEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventCompleted(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventCompletedEventHandler instance = (IScheduledGuildEventCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventCompleted(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> WrapScheduledGuildEventUserAdd<THandler>() where THandler : class, IScheduledGuildEventUserAddEventHandler
=> WrapScheduledGuildEventUserAdd(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserAddEventArgs> WrapScheduledGuildEventUserAdd(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventUserAddEventHandler, ScheduledGuildEventUserAddEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventUserAdd(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventUserAddEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserAddEventHandler instance = (IScheduledGuildEventUserAddEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUserAdd(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> WrapScheduledGuildEventUserRemove<THandler>() where THandler : class, IScheduledGuildEventUserRemoveEventHandler
=> WrapScheduledGuildEventUserRemove(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ScheduledGuildEventUserRemoveEventArgs> WrapScheduledGuildEventUserRemove(Type handler)
#if WrapCore
        => WrapCore<IScheduledGuildEventUserRemoveEventHandler, ScheduledGuildEventUserRemoveEventArgs>(handler, (instance, client, args) => instance.OnScheduledGuildEventUserRemove(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IScheduledGuildEventUserRemoveEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IScheduledGuildEventUserRemoveEventHandler instance = (IScheduledGuildEventUserRemoveEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnScheduledGuildEventUserRemove(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> WrapGuildBanAdd<THandler>() where THandler : class, IGuildBanAddEventHandler
=> WrapGuildBanAdd(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildBanAddEventArgs> WrapGuildBanAdd(Type handler)
#if WrapCore
        => WrapCore<IGuildBanAddEventHandler, GuildBanAddEventArgs>(handler, (instance, client, args) => instance.OnGuildBanAdd(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildBanAddEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanAddEventHandler instance = (IGuildBanAddEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildBanAdd(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> WrapGuildBanRemove<THandler>() where THandler : class, IGuildBanRemoveEventHandler
=> WrapGuildBanRemove(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildBanRemoveEventArgs> WrapGuildBanRemove(Type handler)
#if WrapCore
        => WrapCore<IGuildBanRemoveEventHandler, GuildBanRemoveEventArgs>(handler, (instance, client, args) => instance.OnGuildBanRemove(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildBanRemoveEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildBanRemoveEventHandler instance = (IGuildBanRemoveEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildBanRemove(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> WrapGuildMemberAdd<THandler>() where THandler : class, IGuildMemberAddEventHandler
=> WrapGuildMemberAdd(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildMemberAddEventArgs> WrapGuildMemberAdd(Type handler)
#if WrapCore
        => WrapCore<IGuildMemberAddEventHandler, GuildMemberAddEventArgs>(handler, (instance, client, args) => instance.OnGuildMemberAdd(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildMemberAddEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberAddEventHandler instance = (IGuildMemberAddEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberAdd(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> WrapGuildMemberRemove<THandler>() where THandler : class, IGuildMemberRemoveEventHandler
=> WrapGuildMemberRemove(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildMemberRemoveEventArgs> WrapGuildMemberRemove(Type handler)
#if WrapCore
        => WrapCore<IGuildMemberRemoveEventHandler, GuildMemberRemoveEventArgs>(handler, (instance, client, args) => instance.OnGuildMemberRemove(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildMemberRemoveEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberRemoveEventHandler instance = (IGuildMemberRemoveEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberRemove(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> WrapGuildMemberUpdate<THandler>() where THandler : class, IGuildMemberUpdateEventHandler
=> WrapGuildMemberUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildMemberUpdateEventArgs> WrapGuildMemberUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildMemberUpdateEventHandler, GuildMemberUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildMemberUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildMemberUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMemberUpdateEventHandler instance = (IGuildMemberUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMemberUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> WrapGuildMembersChunk<THandler>() where THandler : class, IGuildMembersChunkEventHandler
=> WrapGuildMembersChunk(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildMembersChunkEventArgs> WrapGuildMembersChunk(Type handler)
#if WrapCore
        => WrapCore<IGuildMembersChunkEventHandler, GuildMembersChunkEventArgs>(handler, (instance, client, args) => instance.OnGuildMembersChunk(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildMembersChunkEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildMembersChunkEventHandler instance = (IGuildMembersChunkEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildMembersChunk(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> WrapGuildRoleCreate<THandler>() where THandler : class, IGuildRoleCreateEventHandler
=> WrapGuildRoleCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildRoleCreateEventArgs> WrapGuildRoleCreate(Type handler)
#if WrapCore
        => WrapCore<IGuildRoleCreateEventHandler, GuildRoleCreateEventArgs>(handler, (instance, client, args) => instance.OnGuildRoleCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildRoleCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleCreateEventHandler instance = (IGuildRoleCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> WrapGuildRoleUpdate<THandler>() where THandler : class, IGuildRoleUpdateEventHandler
=> WrapGuildRoleUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildRoleUpdateEventArgs> WrapGuildRoleUpdate(Type handler)
#if WrapCore
        => WrapCore<IGuildRoleUpdateEventHandler, GuildRoleUpdateEventArgs>(handler, (instance, client, args) => instance.OnGuildRoleUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildRoleUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleUpdateEventHandler instance = (IGuildRoleUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> WrapGuildRoleDelete<THandler>() where THandler : class, IGuildRoleDeleteEventHandler
=> WrapGuildRoleDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, GuildRoleDeleteEventArgs> WrapGuildRoleDelete(Type handler)
#if WrapCore
        => WrapCore<IGuildRoleDeleteEventHandler, GuildRoleDeleteEventArgs>(handler, (instance, client, args) => instance.OnGuildRoleDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IGuildRoleDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IGuildRoleDeleteEventHandler instance = (IGuildRoleDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnGuildRoleDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, InviteCreateEventArgs> WrapInviteCreate<THandler>() where THandler : class, IInviteCreateEventHandler
=> WrapInviteCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, InviteCreateEventArgs> WrapInviteCreate(Type handler)
#if WrapCore
        => WrapCore<IInviteCreateEventHandler, InviteCreateEventArgs>(handler, (instance, client, args) => instance.OnInviteCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IInviteCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteCreateEventHandler instance = (IInviteCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInviteCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> WrapInviteDelete<THandler>() where THandler : class, IInviteDeleteEventHandler
=> WrapInviteDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, InviteDeleteEventArgs> WrapInviteDelete(Type handler)
#if WrapCore
        => WrapCore<IInviteDeleteEventHandler, InviteDeleteEventArgs>(handler, (instance, client, args) => instance.OnInviteDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IInviteDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInviteDeleteEventHandler instance = (IInviteDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInviteDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageCreateEventArgs> WrapMessageCreate<THandler>() where THandler : class, IMessageCreatedEventHandler
=> WrapMessageCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageCreateEventArgs> WrapMessageCreate(Type handler)
#if WrapCore
        => WrapCore<IMessageCreatedEventHandler, MessageCreateEventArgs>(handler, (instance, client, args) => instance.OnMessageCreated(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageCreatedEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageCreatedEventHandler instance = (IMessageCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageCreated(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> WrapMessageAcknowledge<THandler>() where THandler : class, IMessageAcknowledgeEventHandler
=> WrapMessageAcknowledge(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageAcknowledgeEventArgs> WrapMessageAcknowledge(Type handler)
#if WrapCore
        => WrapCore<IMessageAcknowledgeEventHandler, MessageAcknowledgeEventArgs>(handler, (instance, client, args) => instance.OnMessageAcknowledge(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageAcknowledgeEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageAcknowledgeEventHandler instance = (IMessageAcknowledgeEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageAcknowledge(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> WrapMessageUpdate<THandler>() where THandler : class, IMessageUpdateEventHandler
=> WrapMessageUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageUpdateEventArgs> WrapMessageUpdate(Type handler)
#if WrapCore
        => WrapCore<IMessageUpdateEventHandler, MessageUpdateEventArgs>(handler, (instance, client, args) => instance.OnMessageUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageUpdateEventHandler instance = (IMessageUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> WrapMessageDelete<THandler>() where THandler : class, IMessageDeleteEventHandler
=> WrapMessageDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageDeleteEventArgs> WrapMessageDelete(Type handler)
#if WrapCore
        => WrapCore<IMessageDeleteEventHandler, MessageDeleteEventArgs>(handler, (instance, client, args) => instance.OnMessageDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageDeleteEventHandler instance = (IMessageDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> WrapMessageBulkDelete<THandler>() where THandler : class, IMessageBulkDeleteEventHandler
=> WrapMessageBulkDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageBulkDeleteEventArgs> WrapMessageBulkDelete(Type handler)
#if WrapCore
        => WrapCore<IMessageBulkDeleteEventHandler, MessageBulkDeleteEventArgs>(handler, (instance, client, args) => instance.OnMessageBulkDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageBulkDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageBulkDeleteEventHandler instance = (IMessageBulkDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageBulkDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> WrapMessageReactionAdd<THandler>() where THandler : class, IMessageReactionAddEventHandler
=> WrapMessageReactionAdd(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageReactionAddEventArgs> WrapMessageReactionAdd(Type handler)
#if WrapCore
        => WrapCore<IMessageReactionAddEventHandler, MessageReactionAddEventArgs>(handler, (instance, client, args) => instance.OnMessageReactionAdd(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageReactionAddEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionAddEventHandler instance = (IMessageReactionAddEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionAdd(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> WrapMessageReactionRemove<THandler>() where THandler : class, IMessageReactionRemoveEventHandler
=> WrapMessageReactionRemove(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEventArgs> WrapMessageReactionRemove(Type handler)
#if WrapCore
        => WrapCore<IMessageReactionRemoveEventHandler, MessageReactionRemoveEventArgs>(handler, (instance, client, args) => instance.OnMessageReactionRemove(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageReactionRemoveEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemoveEventHandler instance = (IMessageReactionRemoveEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionRemove(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> WrapMessageReactionsClear<THandler>() where THandler : class, IMessageReactionsClearEventHandler
=> WrapMessageReactionsClear(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageReactionsClearEventArgs> WrapMessageReactionsClear(Type handler)
#if WrapCore
        => WrapCore<IMessageReactionsClearEventHandler, MessageReactionsClearEventArgs>(handler, (instance, client, args) => instance.OnMessageReactionsClear(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageReactionsClearEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionsClearEventHandler instance = (IMessageReactionsClearEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionsClear(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> WrapMessageReactionRemoveEmoji<THandler>() where THandler : class, IMessageReactionRemoveEmojiEventHandler
=> WrapMessageReactionRemoveEmoji(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, MessageReactionRemoveEmojiEventArgs> WrapMessageReactionRemoveEmoji(Type handler)
#if WrapCore
        => WrapCore<IMessageReactionRemoveEmojiEventHandler, MessageReactionRemoveEmojiEventArgs>(handler, (instance, client, args) => instance.OnMessageReactionRemoveEmoji(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IMessageReactionRemoveEmojiEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IMessageReactionRemoveEmojiEventHandler instance = (IMessageReactionRemoveEmojiEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnMessageReactionRemoveEmoji(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> WrapPresenceUpdate<THandler>() where THandler : class, IPresenceUpdateEventHandler
=> WrapPresenceUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, PresenceUpdateEventArgs> WrapPresenceUpdate(Type handler)
#if WrapCore
        => WrapCore<IPresenceUpdateEventHandler, PresenceUpdateEventArgs>(handler, (instance, client, args) => instance.OnPresenceUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IPresenceUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IPresenceUpdateEventHandler instance = (IPresenceUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnPresenceUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> WrapUserSettingsUpdate<THandler>() where THandler : class, IUserSettingsUpdateEventHandler
=> WrapUserSettingsUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, UserSettingsUpdateEventArgs> WrapUserSettingsUpdate(Type handler)
#if WrapCore
        => WrapCore<IUserSettingsUpdateEventHandler, UserSettingsUpdateEventArgs>(handler, (instance, client, args) => instance.OnUserSettingsUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IUserSettingsUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserSettingsUpdateEventHandler instance = (IUserSettingsUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnUserSettingsUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, UserUpdateEventArgs> WrapUserUpdate<THandler>() where THandler : class, IUserUpdateEventHandler
=> WrapUserUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, UserUpdateEventArgs> WrapUserUpdate(Type handler)
#if WrapCore
        => WrapCore<IUserUpdateEventHandler, UserUpdateEventArgs>(handler, (instance, client, args) => instance.OnUserUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IUserUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IUserUpdateEventHandler instance = (IUserUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnUserUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> WrapVoiceStateUpdate<THandler>() where THandler : class, IVoiceStateUpdateEventHandler
=> WrapVoiceStateUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, VoiceStateUpdateEventArgs> WrapVoiceStateUpdate(Type handler)
#if WrapCore
        => WrapCore<IVoiceStateUpdateEventHandler, VoiceStateUpdateEventArgs>(handler, (instance, client, args) => instance.OnVoiceStateUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IVoiceStateUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceStateUpdateEventHandler instance = (IVoiceStateUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnVoiceStateUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> WrapVoiceServerUpdate<THandler>() where THandler : class, IVoiceServerUpdateEventHandler
=> WrapVoiceServerUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, VoiceServerUpdateEventArgs> WrapVoiceServerUpdate(Type handler)
#if WrapCore
        => WrapCore<IVoiceServerUpdateEventHandler, VoiceServerUpdateEventArgs>(handler, (instance, client, args) => instance.OnVoiceServerUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IVoiceServerUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IVoiceServerUpdateEventHandler instance = (IVoiceServerUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnVoiceServerUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> WrapThreadCreate<THandler>() where THandler : class, IThreadCreateEventHandler
=> WrapThreadCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadCreateEventArgs> WrapThreadCreate(Type handler)
#if WrapCore
        => WrapCore<IThreadCreateEventHandler, ThreadCreateEventArgs>(handler, (instance, client, args) => instance.OnThreadCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadCreateEventHandler instance = (IThreadCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> WrapThreadUpdate<THandler>() where THandler : class, IThreadUpdateEventHandler
=> WrapThreadUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadUpdateEventArgs> WrapThreadUpdate(Type handler)
#if WrapCore
        => WrapCore<IThreadUpdateEventHandler, ThreadUpdateEventArgs>(handler, (instance, client, args) => instance.OnThreadUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadUpdateEventHandler instance = (IThreadUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> WrapThreadDelete<THandler>() where THandler : class, IThreadDeleteEventHandler
=> WrapThreadDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadDeleteEventArgs> WrapThreadDelete(Type handler)
#if WrapCore
        => WrapCore<IThreadDeleteEventHandler, ThreadDeleteEventArgs>(handler, (instance, client, args) => instance.OnThreadDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadDeleteEventHandler instance = (IThreadDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> WrapThreadListSync<THandler>() where THandler : class, IThreadListSyncEventHandler
=> WrapThreadListSync(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadListSyncEventArgs> WrapThreadListSync(Type handler)
#if WrapCore
        => WrapCore<IThreadListSyncEventHandler, ThreadListSyncEventArgs>(handler, (instance, client, args) => instance.OnThreadListSync(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadListSyncEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadListSyncEventHandler instance = (IThreadListSyncEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadListSync(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> WrapThreadMemberUpdate<THandler>() where THandler : class, IThreadMemberUpdateEventHandler
=> WrapThreadMemberUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadMemberUpdateEventArgs> WrapThreadMemberUpdate(Type handler)
#if WrapCore
        => WrapCore<IThreadMemberUpdateEventHandler, ThreadMemberUpdateEventArgs>(handler, (instance, client, args) => instance.OnThreadMemberUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadMemberUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMemberUpdateEventHandler instance = (IThreadMemberUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadMemberUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> WrapThreadMembersUpdate<THandler>() where THandler : class, IThreadMembersUpdateEventHandler
=> WrapThreadMembersUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ThreadMembersUpdateEventArgs> WrapThreadMembersUpdate(Type handler)
#if WrapCore
        => WrapCore<IThreadMembersUpdateEventHandler, ThreadMembersUpdateEventArgs>(handler, (instance, client, args) => instance.OnThreadMembersUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IThreadMembersUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IThreadMembersUpdateEventHandler instance = (IThreadMembersUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnThreadMembersUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> WrapIntegrationCreate<THandler>() where THandler : class, IIntegrationCreateEventHandler
=> WrapIntegrationCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, IntegrationCreateEventArgs> WrapIntegrationCreate(Type handler)
#if WrapCore
        => WrapCore<IIntegrationCreateEventHandler, IntegrationCreateEventArgs>(handler, (instance, client, args) => instance.OnIntegrationCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IIntegrationCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationCreateEventHandler instance = (IIntegrationCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> WrapIntegrationUpdate<THandler>() where THandler : class, IIntegrationUpdateEventHandler
=> WrapIntegrationUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, IntegrationUpdateEventArgs> WrapIntegrationUpdate(Type handler)
#if WrapCore
        => WrapCore<IIntegrationUpdateEventHandler, IntegrationUpdateEventArgs>(handler, (instance, client, args) => instance.OnIntegrationUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IIntegrationUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationUpdateEventHandler instance = (IIntegrationUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> WrapIntegrationDelete<THandler>() where THandler : class, IIntegrationDeleteEventHandler
=> WrapIntegrationDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, IntegrationDeleteEventArgs> WrapIntegrationDelete(Type handler)
#if WrapCore
        => WrapCore<IIntegrationDeleteEventHandler, IntegrationDeleteEventArgs>(handler, (instance, client, args) => instance.OnIntegrationDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IIntegrationDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IIntegrationDeleteEventHandler instance = (IIntegrationDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnIntegrationDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> WrapStageInstanceCreate<THandler>() where THandler : class, IStageInstanceCreateEventHandler
=> WrapStageInstanceCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, StageInstanceCreateEventArgs> WrapStageInstanceCreate(Type handler)
#if WrapCore
        => WrapCore<IStageInstanceCreateEventHandler, StageInstanceCreateEventArgs>(handler, (instance, client, args) => instance.OnStageInstanceCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IStageInstanceCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceCreateEventHandler instance = (IStageInstanceCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> WrapStageInstanceUpdate<THandler>() where THandler : class, IStageInstanceUpdateEventHandler
=> WrapStageInstanceUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, StageInstanceUpdateEventArgs> WrapStageInstanceUpdate(Type handler)
#if WrapCore
        => WrapCore<IStageInstanceUpdateEventHandler, StageInstanceUpdateEventArgs>(handler, (instance, client, args) => instance.OnStageInstanceUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IStageInstanceUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceUpdateEventHandler instance = (IStageInstanceUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> WrapStageInstanceDelete<THandler>() where THandler : class, IStageInstanceDeleteEventHandler
=> WrapStageInstanceDelete(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, StageInstanceDeleteEventArgs> WrapStageInstanceDelete(Type handler)
#if WrapCore
        => WrapCore<IStageInstanceDeleteEventHandler, StageInstanceDeleteEventArgs>(handler, (instance, client, args) => instance.OnStageInstanceDelete(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IStageInstanceDeleteEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IStageInstanceDeleteEventHandler instance = (IStageInstanceDeleteEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnStageInstanceDelete(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> WrapInteractionCreate<THandler>() where THandler : class, IInteractionCreateEventHandler
=> WrapInteractionCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, InteractionCreateEventArgs> WrapInteractionCreate(Type handler)
#if WrapCore
        => WrapCore<IInteractionCreateEventHandler, InteractionCreateEventArgs>(handler, (instance, client, args) => instance.OnInteractionCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IInteractionCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IInteractionCreateEventHandler instance = (IInteractionCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnInteractionCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> WrapComponentInteractionCreate<THandler>() where THandler : class, IComponentInteractionCreateEventHandler
=> WrapComponentInteractionCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ComponentInteractionCreateEventArgs> WrapComponentInteractionCreate(Type handler)
#if WrapCore
        => WrapCore<IComponentInteractionCreateEventHandler, ComponentInteractionCreateEventArgs>(handler, (instance, client, args) => instance.OnComponentInteractionCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IComponentInteractionCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IComponentInteractionCreateEventHandler instance = (IComponentInteractionCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnComponentInteractionCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> WrapModalSubmit<THandler>() where THandler : class, IModalSubmitEventHandler
=> WrapModalSubmit(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ModalSubmitEventArgs> WrapModalSubmit(Type handler)
#if WrapCore
        => WrapCore<IModalSubmitEventHandler, ModalSubmitEventArgs>(handler, (instance, client, args) => instance.OnModalSubmit(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IModalSubmitEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IModalSubmitEventHandler instance = (IModalSubmitEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnModalSubmit(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> WrapContextMenuInteractionCreate<THandler>() where THandler : class, IContextMenuInteractionCreateEventHandler
=> WrapContextMenuInteractionCreate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ContextMenuInteractionCreateEventArgs> WrapContextMenuInteractionCreate(Type handler)
#if WrapCore
        => WrapCore<IContextMenuInteractionCreateEventHandler, ContextMenuInteractionCreateEventArgs>(handler, (instance, client, args) => instance.OnContextMenuInteractionCreate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IContextMenuInteractionCreateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IContextMenuInteractionCreateEventHandler instance = (IContextMenuInteractionCreateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnContextMenuInteractionCreate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, TypingStartEventArgs> WrapTypingStart<THandler>() where THandler : class, ITypingStartEventHandler
=> WrapTypingStart(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, TypingStartEventArgs> WrapTypingStart(Type handler)
#if WrapCore
        => WrapCore<ITypingStartEventHandler, TypingStartEventArgs>(handler, (instance, client, args) => instance.OnTypingStart(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(ITypingStartEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            ITypingStartEventHandler instance = (ITypingStartEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnTypingStart(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> WrapWebhooksUpdate<THandler>() where THandler : class, IWebhooksUpdateEventHandler
=> WrapWebhooksUpdate(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, WebhooksUpdateEventArgs> WrapWebhooksUpdate(Type handler)
#if WrapCore
        => WrapCore<IWebhooksUpdateEventHandler, WebhooksUpdateEventArgs>(handler, (instance, client, args) => instance.OnWebhooksUpdate(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IWebhooksUpdateEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IWebhooksUpdateEventHandler instance = (IWebhooksUpdateEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnWebhooksUpdate(client, args);
        };
    }
#endif
    public static AsyncEventHandler<DiscordClient, ClientErrorEventArgs> WrapClientError<THandler>() where THandler : class, IClientErrorEventHandler
=> WrapClientError(typeof(THandler));
    public static AsyncEventHandler<DiscordClient, ClientErrorEventArgs> WrapClientError(Type handler)
#if WrapCore
        => WrapCore<IClientErrorEventHandler, ClientErrorEventArgs>(handler, (instance, client, args) => instance.OnClientError(client, args));
#else
    {
        Debug.Assert(handler.IsAssignableTo(typeof(IClientErrorEventHandler)));

        return async (client, args) =>
        {
            EventsNextExtension ctx = client.GetExtension<EventsNextExtension>();
            await using AsyncServiceScope scope = ctx.Provider.CreateAsyncScope();
            IClientErrorEventHandler instance = (IClientErrorEventHandler)scope.ServiceProvider.GetRequiredService(handler);
            await instance.OnClientError(client, args);
        };
    }
#endif
}