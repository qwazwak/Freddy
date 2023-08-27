using System;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;

namespace FreddyBot.Discord;

public static partial class EventBinder
{

    public static void BindSocketOpened<THandler>(DiscordClient client, IServiceProvider provider) where THandler : ISocketOpenedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(ISocketOpenedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(ISocketOpenedEventHandler)}", nameof(THandler));

        client.SocketOpened += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnSocketOpened(sender, args);
        };
    }
    public static void BindSocketOpened(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(ISocketOpenedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(ISocketOpenedEventHandler)}", nameof(handlerType));
        if (!typeof(ISocketOpenedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(ISocketOpenedEventHandler)}", nameof(handlerType));

        client.SocketOpened += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            ISocketOpenedEventHandler handler = (ISocketOpenedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnSocketOpened(sender, args);
        };
    }

    public static void BindSocketClosed<THandler>(DiscordClient client, IServiceProvider provider) where THandler : ISocketClosedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(ISocketClosedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(ISocketClosedEventHandler)}", nameof(THandler));

        client.SocketClosed += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnSocketClosed(sender, args);
        };
    }
    public static void BindSocketClosed(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(ISocketClosedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(ISocketClosedEventHandler)}", nameof(handlerType));
        if (!typeof(ISocketClosedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(ISocketClosedEventHandler)}", nameof(handlerType));

        client.SocketClosed += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            ISocketClosedEventHandler handler = (ISocketClosedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnSocketClosed(sender, args);
        };
    }

    public static void BindReady<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IReadyEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IReadyEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IReadyEventHandler)}", nameof(THandler));

        client.Ready += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnReady(sender, args);
        };
    }
    public static void BindReady(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IReadyEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IReadyEventHandler)}", nameof(handlerType));
        if (!typeof(IReadyEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IReadyEventHandler)}", nameof(handlerType));

        client.Ready += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IReadyEventHandler handler = (IReadyEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnReady(sender, args);
        };
    }

    public static void BindResumed<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IResumedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IResumedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IResumedEventHandler)}", nameof(THandler));

        client.Resumed += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnResumed(sender, args);
        };
    }
    public static void BindResumed(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IResumedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IResumedEventHandler)}", nameof(handlerType));
        if (!typeof(IResumedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IResumedEventHandler)}", nameof(handlerType));

        client.Resumed += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IResumedEventHandler handler = (IResumedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnResumed(sender, args);
        };
    }

    public static void BindHeartbeated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IHeartbeatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IHeartbeatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IHeartbeatedEventHandler)}", nameof(THandler));

        client.Heartbeated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnHeartbeated(sender, args);
        };
    }
    public static void BindHeartbeated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IHeartbeatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IHeartbeatedEventHandler)}", nameof(handlerType));
        if (!typeof(IHeartbeatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IHeartbeatedEventHandler)}", nameof(handlerType));

        client.Heartbeated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IHeartbeatedEventHandler handler = (IHeartbeatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnHeartbeated(sender, args);
        };
    }

    public static void BindZombied<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IZombiedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IZombiedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IZombiedEventHandler)}", nameof(THandler));

        client.Zombied += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnZombied(sender, args);
        };
    }
    public static void BindZombied(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IZombiedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IZombiedEventHandler)}", nameof(handlerType));
        if (!typeof(IZombiedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IZombiedEventHandler)}", nameof(handlerType));

        client.Zombied += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IZombiedEventHandler handler = (IZombiedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnZombied(sender, args);
        };
    }

    public static void BindChannelCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IChannelCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IChannelCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IChannelCreatedEventHandler)}", nameof(THandler));

        client.ChannelCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnChannelCreated(sender, args);
        };
    }
    public static void BindChannelCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IChannelCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IChannelCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IChannelCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IChannelCreatedEventHandler)}", nameof(handlerType));

        client.ChannelCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IChannelCreatedEventHandler handler = (IChannelCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnChannelCreated(sender, args);
        };
    }

    public static void BindChannelUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IChannelUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IChannelUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IChannelUpdatedEventHandler)}", nameof(THandler));

        client.ChannelUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnChannelUpdated(sender, args);
        };
    }
    public static void BindChannelUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IChannelUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IChannelUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IChannelUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IChannelUpdatedEventHandler)}", nameof(handlerType));

        client.ChannelUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IChannelUpdatedEventHandler handler = (IChannelUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnChannelUpdated(sender, args);
        };
    }

    public static void BindChannelDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IChannelDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IChannelDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IChannelDeletedEventHandler)}", nameof(THandler));

        client.ChannelDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnChannelDeleted(sender, args);
        };
    }
    public static void BindChannelDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IChannelDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IChannelDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IChannelDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IChannelDeletedEventHandler)}", nameof(handlerType));

        client.ChannelDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IChannelDeletedEventHandler handler = (IChannelDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnChannelDeleted(sender, args);
        };
    }

    public static void BindDmChannelDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IDmChannelDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IDmChannelDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IDmChannelDeletedEventHandler)}", nameof(THandler));

        client.DmChannelDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnDmChannelDeleted(sender, args);
        };
    }
    public static void BindDmChannelDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IDmChannelDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IDmChannelDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IDmChannelDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IDmChannelDeletedEventHandler)}", nameof(handlerType));

        client.DmChannelDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IDmChannelDeletedEventHandler handler = (IDmChannelDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnDmChannelDeleted(sender, args);
        };
    }

    public static void BindChannelPinsUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IChannelPinsUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IChannelPinsUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IChannelPinsUpdatedEventHandler)}", nameof(THandler));

        client.ChannelPinsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnChannelPinsUpdated(sender, args);
        };
    }
    public static void BindChannelPinsUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IChannelPinsUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IChannelPinsUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IChannelPinsUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IChannelPinsUpdatedEventHandler)}", nameof(handlerType));

        client.ChannelPinsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IChannelPinsUpdatedEventHandler handler = (IChannelPinsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnChannelPinsUpdated(sender, args);
        };
    }

    public static void BindGuildCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildCreatedEventHandler)}", nameof(THandler));

        client.GuildCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildCreated(sender, args);
        };
    }
    public static void BindGuildCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildCreatedEventHandler)}", nameof(handlerType));

        client.GuildCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildCreatedEventHandler handler = (IGuildCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildCreated(sender, args);
        };
    }

    public static void BindGuildAvailable<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildAvailableEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildAvailableEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildAvailableEventHandler)}", nameof(THandler));

        client.GuildAvailable += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildAvailable(sender, args);
        };
    }
    public static void BindGuildAvailable(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildAvailableEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildAvailableEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildAvailableEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildAvailableEventHandler)}", nameof(handlerType));

        client.GuildAvailable += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildAvailableEventHandler handler = (IGuildAvailableEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildAvailable(sender, args);
        };
    }

    public static void BindGuildUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildUpdatedEventHandler)}", nameof(THandler));

        client.GuildUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildUpdated(sender, args);
        };
    }
    public static void BindGuildUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildUpdatedEventHandler)}", nameof(handlerType));

        client.GuildUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildUpdatedEventHandler handler = (IGuildUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildUpdated(sender, args);
        };
    }

    public static void BindGuildDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildDeletedEventHandler)}", nameof(THandler));

        client.GuildDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildDeleted(sender, args);
        };
    }
    public static void BindGuildDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildDeletedEventHandler)}", nameof(handlerType));

        client.GuildDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildDeletedEventHandler handler = (IGuildDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildDeleted(sender, args);
        };
    }

    public static void BindGuildUnavailable<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildUnavailableEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildUnavailableEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildUnavailableEventHandler)}", nameof(THandler));

        client.GuildUnavailable += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildUnavailable(sender, args);
        };
    }
    public static void BindGuildUnavailable(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildUnavailableEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildUnavailableEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildUnavailableEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildUnavailableEventHandler)}", nameof(handlerType));

        client.GuildUnavailable += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildUnavailableEventHandler handler = (IGuildUnavailableEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildUnavailable(sender, args);
        };
    }

    public static void BindGuildDownloadCompleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildDownloadCompletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildDownloadCompletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildDownloadCompletedEventHandler)}", nameof(THandler));

        client.GuildDownloadCompleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildDownloadCompleted(sender, args);
        };
    }
    public static void BindGuildDownloadCompleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildDownloadCompletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildDownloadCompletedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildDownloadCompletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildDownloadCompletedEventHandler)}", nameof(handlerType));

        client.GuildDownloadCompleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildDownloadCompletedEventHandler handler = (IGuildDownloadCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildDownloadCompleted(sender, args);
        };
    }

    public static void BindGuildEmojisUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildEmojisUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildEmojisUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildEmojisUpdatedEventHandler)}", nameof(THandler));

        client.GuildEmojisUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildEmojisUpdated(sender, args);
        };
    }
    public static void BindGuildEmojisUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildEmojisUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildEmojisUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildEmojisUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildEmojisUpdatedEventHandler)}", nameof(handlerType));

        client.GuildEmojisUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildEmojisUpdatedEventHandler handler = (IGuildEmojisUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildEmojisUpdated(sender, args);
        };
    }

    public static void BindGuildStickersUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildStickersUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildStickersUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildStickersUpdatedEventHandler)}", nameof(THandler));

        client.GuildStickersUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildStickersUpdated(sender, args);
        };
    }
    public static void BindGuildStickersUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildStickersUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildStickersUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildStickersUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildStickersUpdatedEventHandler)}", nameof(handlerType));

        client.GuildStickersUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildStickersUpdatedEventHandler handler = (IGuildStickersUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildStickersUpdated(sender, args);
        };
    }

    public static void BindGuildIntegrationsUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildIntegrationsUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildIntegrationsUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildIntegrationsUpdatedEventHandler)}", nameof(THandler));

        client.GuildIntegrationsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildIntegrationsUpdated(sender, args);
        };
    }
    public static void BindGuildIntegrationsUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildIntegrationsUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildIntegrationsUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildIntegrationsUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildIntegrationsUpdatedEventHandler)}", nameof(handlerType));

        client.GuildIntegrationsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildIntegrationsUpdatedEventHandler handler = (IGuildIntegrationsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildIntegrationsUpdated(sender, args);
        };
    }

    public static void BindScheduledGuildEventCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventCreatedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventCreated(sender, args);
        };
    }
    public static void BindScheduledGuildEventCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventCreatedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventCreatedEventHandler handler = (IScheduledGuildEventCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventCreated(sender, args);
        };
    }

    public static void BindScheduledGuildEventUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventUpdatedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventUpdated(sender, args);
        };
    }
    public static void BindScheduledGuildEventUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventUpdatedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventUpdatedEventHandler handler = (IScheduledGuildEventUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventUpdated(sender, args);
        };
    }

    public static void BindScheduledGuildEventDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventDeletedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventDeleted(sender, args);
        };
    }
    public static void BindScheduledGuildEventDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventDeletedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventDeletedEventHandler handler = (IScheduledGuildEventDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventDeleted(sender, args);
        };
    }

    public static void BindScheduledGuildEventCompleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventCompletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventCompletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventCompletedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventCompleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventCompleted(sender, args);
        };
    }
    public static void BindScheduledGuildEventCompleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventCompletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventCompletedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventCompletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventCompletedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventCompleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventCompletedEventHandler handler = (IScheduledGuildEventCompletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventCompleted(sender, args);
        };
    }

    public static void BindScheduledGuildEventUserAdded<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventUserAddedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventUserAddedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventUserAddedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventUserAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventUserAdded(sender, args);
        };
    }
    public static void BindScheduledGuildEventUserAdded(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventUserAddedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventUserAddedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventUserAddedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventUserAddedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventUserAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventUserAddedEventHandler handler = (IScheduledGuildEventUserAddedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventUserAdded(sender, args);
        };
    }

    public static void BindScheduledGuildEventUserRemoved<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IScheduledGuildEventUserRemovedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IScheduledGuildEventUserRemovedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IScheduledGuildEventUserRemovedEventHandler)}", nameof(THandler));

        client.ScheduledGuildEventUserRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnScheduledGuildEventUserRemoved(sender, args);
        };
    }
    public static void BindScheduledGuildEventUserRemoved(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IScheduledGuildEventUserRemovedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IScheduledGuildEventUserRemovedEventHandler)}", nameof(handlerType));
        if (!typeof(IScheduledGuildEventUserRemovedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IScheduledGuildEventUserRemovedEventHandler)}", nameof(handlerType));

        client.ScheduledGuildEventUserRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IScheduledGuildEventUserRemovedEventHandler handler = (IScheduledGuildEventUserRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnScheduledGuildEventUserRemoved(sender, args);
        };
    }

    public static void BindGuildBanAdded<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildBanAddedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildBanAddedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildBanAddedEventHandler)}", nameof(THandler));

        client.GuildBanAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildBanAdded(sender, args);
        };
    }
    public static void BindGuildBanAdded(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildBanAddedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildBanAddedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildBanAddedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildBanAddedEventHandler)}", nameof(handlerType));

        client.GuildBanAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildBanAddedEventHandler handler = (IGuildBanAddedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildBanAdded(sender, args);
        };
    }

    public static void BindGuildBanRemoved<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildBanRemovedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildBanRemovedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildBanRemovedEventHandler)}", nameof(THandler));

        client.GuildBanRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildBanRemoved(sender, args);
        };
    }
    public static void BindGuildBanRemoved(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildBanRemovedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildBanRemovedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildBanRemovedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildBanRemovedEventHandler)}", nameof(handlerType));

        client.GuildBanRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildBanRemovedEventHandler handler = (IGuildBanRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildBanRemoved(sender, args);
        };
    }

    public static void BindGuildMemberAdded<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildMemberAddedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildMemberAddedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildMemberAddedEventHandler)}", nameof(THandler));

        client.GuildMemberAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildMemberAdded(sender, args);
        };
    }
    public static void BindGuildMemberAdded(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildMemberAddedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildMemberAddedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildMemberAddedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildMemberAddedEventHandler)}", nameof(handlerType));

        client.GuildMemberAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildMemberAddedEventHandler handler = (IGuildMemberAddedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildMemberAdded(sender, args);
        };
    }

    public static void BindGuildMemberRemoved<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildMemberRemovedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildMemberRemovedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildMemberRemovedEventHandler)}", nameof(THandler));

        client.GuildMemberRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildMemberRemoved(sender, args);
        };
    }
    public static void BindGuildMemberRemoved(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildMemberRemovedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildMemberRemovedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildMemberRemovedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildMemberRemovedEventHandler)}", nameof(handlerType));

        client.GuildMemberRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildMemberRemovedEventHandler handler = (IGuildMemberRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildMemberRemoved(sender, args);
        };
    }

    public static void BindGuildMemberUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildMemberUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildMemberUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildMemberUpdatedEventHandler)}", nameof(THandler));

        client.GuildMemberUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildMemberUpdated(sender, args);
        };
    }
    public static void BindGuildMemberUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildMemberUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildMemberUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildMemberUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildMemberUpdatedEventHandler)}", nameof(handlerType));

        client.GuildMemberUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildMemberUpdatedEventHandler handler = (IGuildMemberUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildMemberUpdated(sender, args);
        };
    }

    public static void BindGuildMembersChunked<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildMembersChunkedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildMembersChunkedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildMembersChunkedEventHandler)}", nameof(THandler));

        client.GuildMembersChunked += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildMembersChunked(sender, args);
        };
    }
    public static void BindGuildMembersChunked(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildMembersChunkedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildMembersChunkedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildMembersChunkedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildMembersChunkedEventHandler)}", nameof(handlerType));

        client.GuildMembersChunked += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildMembersChunkedEventHandler handler = (IGuildMembersChunkedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildMembersChunked(sender, args);
        };
    }

    public static void BindGuildRoleCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildRoleCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildRoleCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildRoleCreatedEventHandler)}", nameof(THandler));

        client.GuildRoleCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildRoleCreated(sender, args);
        };
    }
    public static void BindGuildRoleCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildRoleCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildRoleCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildRoleCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildRoleCreatedEventHandler)}", nameof(handlerType));

        client.GuildRoleCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildRoleCreatedEventHandler handler = (IGuildRoleCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildRoleCreated(sender, args);
        };
    }

    public static void BindGuildRoleUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildRoleUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildRoleUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildRoleUpdatedEventHandler)}", nameof(THandler));

        client.GuildRoleUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildRoleUpdated(sender, args);
        };
    }
    public static void BindGuildRoleUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildRoleUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildRoleUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildRoleUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildRoleUpdatedEventHandler)}", nameof(handlerType));

        client.GuildRoleUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildRoleUpdatedEventHandler handler = (IGuildRoleUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildRoleUpdated(sender, args);
        };
    }

    public static void BindGuildRoleDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IGuildRoleDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IGuildRoleDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IGuildRoleDeletedEventHandler)}", nameof(THandler));

        client.GuildRoleDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnGuildRoleDeleted(sender, args);
        };
    }
    public static void BindGuildRoleDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IGuildRoleDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IGuildRoleDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IGuildRoleDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IGuildRoleDeletedEventHandler)}", nameof(handlerType));

        client.GuildRoleDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IGuildRoleDeletedEventHandler handler = (IGuildRoleDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnGuildRoleDeleted(sender, args);
        };
    }

    public static void BindInviteCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IInviteCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IInviteCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IInviteCreatedEventHandler)}", nameof(THandler));

        client.InviteCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnInviteCreated(sender, args);
        };
    }
    public static void BindInviteCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IInviteCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IInviteCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IInviteCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IInviteCreatedEventHandler)}", nameof(handlerType));

        client.InviteCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IInviteCreatedEventHandler handler = (IInviteCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnInviteCreated(sender, args);
        };
    }

    public static void BindInviteDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IInviteDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IInviteDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IInviteDeletedEventHandler)}", nameof(THandler));

        client.InviteDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnInviteDeleted(sender, args);
        };
    }
    public static void BindInviteDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IInviteDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IInviteDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IInviteDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IInviteDeletedEventHandler)}", nameof(handlerType));

        client.InviteDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IInviteDeletedEventHandler handler = (IInviteDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnInviteDeleted(sender, args);
        };
    }

    public static void BindMessageCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageCreatedEventHandler)}", nameof(THandler));

        client.MessageCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageCreated(sender, args);
        };
    }
    public static void BindMessageCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageCreatedEventHandler)}", nameof(handlerType));

        client.MessageCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageCreatedEventHandler handler = (IMessageCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageCreated(sender, args);
        };
    }

    public static void BindMessageAcknowledged<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageAcknowledgedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageAcknowledgedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageAcknowledgedEventHandler)}", nameof(THandler));

        client.MessageAcknowledged += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageAcknowledged(sender, args);
        };
    }
    public static void BindMessageAcknowledged(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageAcknowledgedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageAcknowledgedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageAcknowledgedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageAcknowledgedEventHandler)}", nameof(handlerType));

        client.MessageAcknowledged += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageAcknowledgedEventHandler handler = (IMessageAcknowledgedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageAcknowledged(sender, args);
        };
    }

    public static void BindMessageUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageUpdatedEventHandler)}", nameof(THandler));

        client.MessageUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageUpdated(sender, args);
        };
    }
    public static void BindMessageUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageUpdatedEventHandler)}", nameof(handlerType));

        client.MessageUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageUpdatedEventHandler handler = (IMessageUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageUpdated(sender, args);
        };
    }

    public static void BindMessageDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageDeletedEventHandler)}", nameof(THandler));

        client.MessageDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageDeleted(sender, args);
        };
    }
    public static void BindMessageDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageDeletedEventHandler)}", nameof(handlerType));

        client.MessageDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageDeletedEventHandler handler = (IMessageDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageDeleted(sender, args);
        };
    }

    public static void BindMessagesBulkDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessagesBulkDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessagesBulkDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessagesBulkDeletedEventHandler)}", nameof(THandler));

        client.MessagesBulkDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessagesBulkDeleted(sender, args);
        };
    }
    public static void BindMessagesBulkDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessagesBulkDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessagesBulkDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessagesBulkDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessagesBulkDeletedEventHandler)}", nameof(handlerType));

        client.MessagesBulkDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessagesBulkDeletedEventHandler handler = (IMessagesBulkDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessagesBulkDeleted(sender, args);
        };
    }

    public static void BindMessageReactionAdded<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageReactionAddedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageReactionAddedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageReactionAddedEventHandler)}", nameof(THandler));

        client.MessageReactionAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageReactionAdded(sender, args);
        };
    }
    public static void BindMessageReactionAdded(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageReactionAddedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageReactionAddedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageReactionAddedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageReactionAddedEventHandler)}", nameof(handlerType));

        client.MessageReactionAdded += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageReactionAddedEventHandler handler = (IMessageReactionAddedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageReactionAdded(sender, args);
        };
    }

    public static void BindMessageReactionRemoved<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageReactionRemovedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageReactionRemovedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageReactionRemovedEventHandler)}", nameof(THandler));

        client.MessageReactionRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageReactionRemoved(sender, args);
        };
    }
    public static void BindMessageReactionRemoved(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageReactionRemovedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageReactionRemovedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageReactionRemovedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageReactionRemovedEventHandler)}", nameof(handlerType));

        client.MessageReactionRemoved += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageReactionRemovedEventHandler handler = (IMessageReactionRemovedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageReactionRemoved(sender, args);
        };
    }

    public static void BindMessageReactionsCleared<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageReactionsClearedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageReactionsClearedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageReactionsClearedEventHandler)}", nameof(THandler));

        client.MessageReactionsCleared += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageReactionsCleared(sender, args);
        };
    }
    public static void BindMessageReactionsCleared(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageReactionsClearedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageReactionsClearedEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageReactionsClearedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageReactionsClearedEventHandler)}", nameof(handlerType));

        client.MessageReactionsCleared += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageReactionsClearedEventHandler handler = (IMessageReactionsClearedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageReactionsCleared(sender, args);
        };
    }

    public static void BindMessageReactionRemovedEmoji<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IMessageReactionRemovedEmojiEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IMessageReactionRemovedEmojiEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IMessageReactionRemovedEmojiEventHandler)}", nameof(THandler));

        client.MessageReactionRemovedEmoji += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnMessageReactionRemovedEmoji(sender, args);
        };
    }
    public static void BindMessageReactionRemovedEmoji(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IMessageReactionRemovedEmojiEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IMessageReactionRemovedEmojiEventHandler)}", nameof(handlerType));
        if (!typeof(IMessageReactionRemovedEmojiEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IMessageReactionRemovedEmojiEventHandler)}", nameof(handlerType));

        client.MessageReactionRemovedEmoji += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IMessageReactionRemovedEmojiEventHandler handler = (IMessageReactionRemovedEmojiEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnMessageReactionRemovedEmoji(sender, args);
        };
    }

    public static void BindPresenceUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IPresenceUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IPresenceUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IPresenceUpdatedEventHandler)}", nameof(THandler));

        client.PresenceUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnPresenceUpdated(sender, args);
        };
    }
    public static void BindPresenceUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IPresenceUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IPresenceUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IPresenceUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IPresenceUpdatedEventHandler)}", nameof(handlerType));

        client.PresenceUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IPresenceUpdatedEventHandler handler = (IPresenceUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnPresenceUpdated(sender, args);
        };
    }

    public static void BindUserSettingsUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IUserSettingsUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IUserSettingsUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IUserSettingsUpdatedEventHandler)}", nameof(THandler));

        client.UserSettingsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnUserSettingsUpdated(sender, args);
        };
    }
    public static void BindUserSettingsUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IUserSettingsUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IUserSettingsUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IUserSettingsUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IUserSettingsUpdatedEventHandler)}", nameof(handlerType));

        client.UserSettingsUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IUserSettingsUpdatedEventHandler handler = (IUserSettingsUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnUserSettingsUpdated(sender, args);
        };
    }

    public static void BindUserUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IUserUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IUserUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IUserUpdatedEventHandler)}", nameof(THandler));

        client.UserUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnUserUpdated(sender, args);
        };
    }
    public static void BindUserUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IUserUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IUserUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IUserUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IUserUpdatedEventHandler)}", nameof(handlerType));

        client.UserUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IUserUpdatedEventHandler handler = (IUserUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnUserUpdated(sender, args);
        };
    }

    public static void BindVoiceStateUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IVoiceStateUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IVoiceStateUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IVoiceStateUpdatedEventHandler)}", nameof(THandler));

        client.VoiceStateUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnVoiceStateUpdated(sender, args);
        };
    }
    public static void BindVoiceStateUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IVoiceStateUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IVoiceStateUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IVoiceStateUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IVoiceStateUpdatedEventHandler)}", nameof(handlerType));

        client.VoiceStateUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IVoiceStateUpdatedEventHandler handler = (IVoiceStateUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnVoiceStateUpdated(sender, args);
        };
    }

    public static void BindVoiceServerUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IVoiceServerUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IVoiceServerUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IVoiceServerUpdatedEventHandler)}", nameof(THandler));

        client.VoiceServerUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnVoiceServerUpdated(sender, args);
        };
    }
    public static void BindVoiceServerUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IVoiceServerUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IVoiceServerUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IVoiceServerUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IVoiceServerUpdatedEventHandler)}", nameof(handlerType));

        client.VoiceServerUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IVoiceServerUpdatedEventHandler handler = (IVoiceServerUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnVoiceServerUpdated(sender, args);
        };
    }

    public static void BindThreadCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadCreatedEventHandler)}", nameof(THandler));

        client.ThreadCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadCreated(sender, args);
        };
    }
    public static void BindThreadCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadCreatedEventHandler)}", nameof(handlerType));

        client.ThreadCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadCreatedEventHandler handler = (IThreadCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadCreated(sender, args);
        };
    }

    public static void BindThreadUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadUpdatedEventHandler)}", nameof(THandler));

        client.ThreadUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadUpdated(sender, args);
        };
    }
    public static void BindThreadUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadUpdatedEventHandler)}", nameof(handlerType));

        client.ThreadUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadUpdatedEventHandler handler = (IThreadUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadUpdated(sender, args);
        };
    }

    public static void BindThreadDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadDeletedEventHandler)}", nameof(THandler));

        client.ThreadDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadDeleted(sender, args);
        };
    }
    public static void BindThreadDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadDeletedEventHandler)}", nameof(handlerType));

        client.ThreadDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadDeletedEventHandler handler = (IThreadDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadDeleted(sender, args);
        };
    }

    public static void BindThreadListSynced<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadListSyncedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadListSyncedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadListSyncedEventHandler)}", nameof(THandler));

        client.ThreadListSynced += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadListSynced(sender, args);
        };
    }
    public static void BindThreadListSynced(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadListSyncedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadListSyncedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadListSyncedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadListSyncedEventHandler)}", nameof(handlerType));

        client.ThreadListSynced += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadListSyncedEventHandler handler = (IThreadListSyncedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadListSynced(sender, args);
        };
    }

    public static void BindThreadMemberUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadMemberUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadMemberUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadMemberUpdatedEventHandler)}", nameof(THandler));

        client.ThreadMemberUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadMemberUpdated(sender, args);
        };
    }
    public static void BindThreadMemberUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadMemberUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadMemberUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadMemberUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadMemberUpdatedEventHandler)}", nameof(handlerType));

        client.ThreadMemberUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadMemberUpdatedEventHandler handler = (IThreadMemberUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadMemberUpdated(sender, args);
        };
    }

    public static void BindThreadMembersUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IThreadMembersUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IThreadMembersUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IThreadMembersUpdatedEventHandler)}", nameof(THandler));

        client.ThreadMembersUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnThreadMembersUpdated(sender, args);
        };
    }
    public static void BindThreadMembersUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IThreadMembersUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IThreadMembersUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IThreadMembersUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IThreadMembersUpdatedEventHandler)}", nameof(handlerType));

        client.ThreadMembersUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IThreadMembersUpdatedEventHandler handler = (IThreadMembersUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnThreadMembersUpdated(sender, args);
        };
    }

    public static void BindIntegrationCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IIntegrationCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IIntegrationCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IIntegrationCreatedEventHandler)}", nameof(THandler));

        client.IntegrationCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnIntegrationCreated(sender, args);
        };
    }
    public static void BindIntegrationCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IIntegrationCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IIntegrationCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IIntegrationCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IIntegrationCreatedEventHandler)}", nameof(handlerType));

        client.IntegrationCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IIntegrationCreatedEventHandler handler = (IIntegrationCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnIntegrationCreated(sender, args);
        };
    }

    public static void BindIntegrationUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IIntegrationUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IIntegrationUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IIntegrationUpdatedEventHandler)}", nameof(THandler));

        client.IntegrationUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnIntegrationUpdated(sender, args);
        };
    }
    public static void BindIntegrationUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IIntegrationUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IIntegrationUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IIntegrationUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IIntegrationUpdatedEventHandler)}", nameof(handlerType));

        client.IntegrationUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IIntegrationUpdatedEventHandler handler = (IIntegrationUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnIntegrationUpdated(sender, args);
        };
    }

    public static void BindIntegrationDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IIntegrationDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IIntegrationDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IIntegrationDeletedEventHandler)}", nameof(THandler));

        client.IntegrationDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnIntegrationDeleted(sender, args);
        };
    }
    public static void BindIntegrationDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IIntegrationDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IIntegrationDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IIntegrationDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IIntegrationDeletedEventHandler)}", nameof(handlerType));

        client.IntegrationDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IIntegrationDeletedEventHandler handler = (IIntegrationDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnIntegrationDeleted(sender, args);
        };
    }

    public static void BindStageInstanceCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IStageInstanceCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IStageInstanceCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IStageInstanceCreatedEventHandler)}", nameof(THandler));

        client.StageInstanceCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnStageInstanceCreated(sender, args);
        };
    }
    public static void BindStageInstanceCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IStageInstanceCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IStageInstanceCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IStageInstanceCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IStageInstanceCreatedEventHandler)}", nameof(handlerType));

        client.StageInstanceCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IStageInstanceCreatedEventHandler handler = (IStageInstanceCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnStageInstanceCreated(sender, args);
        };
    }

    public static void BindStageInstanceUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IStageInstanceUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IStageInstanceUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IStageInstanceUpdatedEventHandler)}", nameof(THandler));

        client.StageInstanceUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnStageInstanceUpdated(sender, args);
        };
    }
    public static void BindStageInstanceUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IStageInstanceUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IStageInstanceUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IStageInstanceUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IStageInstanceUpdatedEventHandler)}", nameof(handlerType));

        client.StageInstanceUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IStageInstanceUpdatedEventHandler handler = (IStageInstanceUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnStageInstanceUpdated(sender, args);
        };
    }

    public static void BindStageInstanceDeleted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IStageInstanceDeletedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IStageInstanceDeletedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IStageInstanceDeletedEventHandler)}", nameof(THandler));

        client.StageInstanceDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnStageInstanceDeleted(sender, args);
        };
    }
    public static void BindStageInstanceDeleted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IStageInstanceDeletedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IStageInstanceDeletedEventHandler)}", nameof(handlerType));
        if (!typeof(IStageInstanceDeletedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IStageInstanceDeletedEventHandler)}", nameof(handlerType));

        client.StageInstanceDeleted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IStageInstanceDeletedEventHandler handler = (IStageInstanceDeletedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnStageInstanceDeleted(sender, args);
        };
    }

    public static void BindInteractionCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IInteractionCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IInteractionCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IInteractionCreatedEventHandler)}", nameof(THandler));

        client.InteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnInteractionCreated(sender, args);
        };
    }
    public static void BindInteractionCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IInteractionCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IInteractionCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IInteractionCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IInteractionCreatedEventHandler)}", nameof(handlerType));

        client.InteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IInteractionCreatedEventHandler handler = (IInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnInteractionCreated(sender, args);
        };
    }

    public static void BindComponentInteractionCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IComponentInteractionCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IComponentInteractionCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IComponentInteractionCreatedEventHandler)}", nameof(THandler));

        client.ComponentInteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnComponentInteractionCreated(sender, args);
        };
    }
    public static void BindComponentInteractionCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IComponentInteractionCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IComponentInteractionCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IComponentInteractionCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IComponentInteractionCreatedEventHandler)}", nameof(handlerType));

        client.ComponentInteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IComponentInteractionCreatedEventHandler handler = (IComponentInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnComponentInteractionCreated(sender, args);
        };
    }

    public static void BindModalSubmitted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IModalSubmittedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IModalSubmittedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IModalSubmittedEventHandler)}", nameof(THandler));

        client.ModalSubmitted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnModalSubmitted(sender, args);
        };
    }
    public static void BindModalSubmitted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IModalSubmittedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IModalSubmittedEventHandler)}", nameof(handlerType));
        if (!typeof(IModalSubmittedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IModalSubmittedEventHandler)}", nameof(handlerType));

        client.ModalSubmitted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IModalSubmittedEventHandler handler = (IModalSubmittedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnModalSubmitted(sender, args);
        };
    }

    public static void BindContextMenuInteractionCreated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IContextMenuInteractionCreatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IContextMenuInteractionCreatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IContextMenuInteractionCreatedEventHandler)}", nameof(THandler));

        client.ContextMenuInteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnContextMenuInteractionCreated(sender, args);
        };
    }
    public static void BindContextMenuInteractionCreated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IContextMenuInteractionCreatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IContextMenuInteractionCreatedEventHandler)}", nameof(handlerType));
        if (!typeof(IContextMenuInteractionCreatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IContextMenuInteractionCreatedEventHandler)}", nameof(handlerType));

        client.ContextMenuInteractionCreated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IContextMenuInteractionCreatedEventHandler handler = (IContextMenuInteractionCreatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnContextMenuInteractionCreated(sender, args);
        };
    }

    public static void BindTypingStarted<THandler>(DiscordClient client, IServiceProvider provider) where THandler : ITypingStartedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(ITypingStartedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(ITypingStartedEventHandler)}", nameof(THandler));

        client.TypingStarted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnTypingStarted(sender, args);
        };
    }
    public static void BindTypingStarted(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(ITypingStartedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(ITypingStartedEventHandler)}", nameof(handlerType));
        if (!typeof(ITypingStartedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(ITypingStartedEventHandler)}", nameof(handlerType));

        client.TypingStarted += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            ITypingStartedEventHandler handler = (ITypingStartedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnTypingStarted(sender, args);
        };
    }

    public static void BindUnknownEvent<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IUnknownEventEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IUnknownEventEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IUnknownEventEventHandler)}", nameof(THandler));

        client.UnknownEvent += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnUnknownEvent(sender, args);
        };
    }
    public static void BindUnknownEvent(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IUnknownEventEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IUnknownEventEventHandler)}", nameof(handlerType));
        if (!typeof(IUnknownEventEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IUnknownEventEventHandler)}", nameof(handlerType));

        client.UnknownEvent += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IUnknownEventEventHandler handler = (IUnknownEventEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnUnknownEvent(sender, args);
        };
    }

    public static void BindWebhooksUpdated<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IWebhooksUpdatedEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IWebhooksUpdatedEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IWebhooksUpdatedEventHandler)}", nameof(THandler));

        client.WebhooksUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnWebhooksUpdated(sender, args);
        };
    }
    public static void BindWebhooksUpdated(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IWebhooksUpdatedEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IWebhooksUpdatedEventHandler)}", nameof(handlerType));
        if (!typeof(IWebhooksUpdatedEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IWebhooksUpdatedEventHandler)}", nameof(handlerType));

        client.WebhooksUpdated += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IWebhooksUpdatedEventHandler handler = (IWebhooksUpdatedEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnWebhooksUpdated(sender, args);
        };
    }

    public static void BindClientErrored<THandler>(DiscordClient client, IServiceProvider provider) where THandler : IClientErroredEventHandler
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        if (typeof(THandler) == typeof(IClientErroredEventHandler))
            throw new ArgumentException($"{nameof(THandler)} must not be the interface {nameof(IClientErroredEventHandler)}", nameof(THandler));

        client.ClientErrored += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            THandler handler = scope.ServiceProvider.GetRequiredService<THandler>();
            await handler.OnClientErrored(sender, args);
        };
    }
    public static void BindClientErrored(DiscordClient client, IServiceProvider provider, Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(provider);
        ArgumentNullException.ThrowIfNull(handlerType);
        if (handlerType == typeof(IClientErroredEventHandler))
            throw new ArgumentException($"{handlerType.Name} must not be the interface {nameof(IClientErroredEventHandler)}", nameof(handlerType));
        if (!typeof(IClientErroredEventHandler).IsAssignableFrom(handlerType) )
            throw new ArgumentException($"{nameof(handlerType)} must be assignable to the interface {nameof(IClientErroredEventHandler)}", nameof(handlerType));

        client.ClientErrored += async (sender, args) =>
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            IClientErroredEventHandler handler = (IClientErroredEventHandler)scope.ServiceProvider.GetRequiredService(handlerType);
            await handler.OnClientErrored(sender, args);
        };
    }
}
