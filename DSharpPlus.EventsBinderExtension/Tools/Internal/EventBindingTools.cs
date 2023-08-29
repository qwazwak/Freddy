using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.EventsBinderExtension.Entities;

namespace DSharpPlus.EventsBinderExtension.Tools.Internal;

internal static partial class EventBindingTools
{
    public static void BindAllHandlers(DiscordClient client, IEnumerable<Type> handlers)
    {
        foreach (Type handler in handlers)
            BindHandler(client, handler);
    }

    public static void BindHandler<THandler>(DiscordClient client) where THandler : class, IDiscordEventHandler => BindHandler(client, typeof(THandler));

    public static void BindHandler(DiscordClient client, Type handler)
    {
        if (handler.IsAssignableTo(typeof(ISocketOpenedEventHandler)))
            client.SocketOpened += EventBinderWrappers.WrapSocketOpened(handler);
        if (handler.IsAssignableTo(typeof(ISocketClosedEventHandler)))
            client.SocketClosed += EventBinderWrappers.WrapSocketClosed(handler);
        if (handler.IsAssignableTo(typeof(IResumedEventHandler)))
            client.Resumed += EventBinderWrappers.WrapResumed(handler);
        if (handler.IsAssignableTo(typeof(IHeartbeatEventHandler)))
            client.Heartbeated += EventBinderWrappers.WrapHeartbeated(handler);
        if (handler.IsAssignableTo(typeof(IChannelCreatedEventHandler)))
            client.ChannelCreated += EventBinderWrappers.WrapOnChannelCreate(handler);
        if (handler.IsAssignableTo(typeof(IReadyEventHandler)))
            client.Ready += EventBinderWrappers.WrapReady(handler);
        if (handler.IsAssignableTo(typeof(IZombiedEventHandler)))
            client.Zombied += EventBinderWrappers.WrapZombied(handler);
        if (handler.IsAssignableTo(typeof(IChannelUpdateEventHandler)))
            client.ChannelUpdated += EventBinderWrappers.WrapChannelUpdate(handler);
        if (handler.IsAssignableTo(typeof(IChannelDeleteEventHandler)))
            client.ChannelDeleted += EventBinderWrappers.WrapChannelDelete(handler);
        if (handler.IsAssignableTo(typeof(IDmChannelDeleteEventHandler)))
            client.DmChannelDeleted += EventBinderWrappers.WrapDmChannelDelete(handler);
        if (handler.IsAssignableTo(typeof(IChannelPinsUpdateEventHandler)))
            client.ChannelPinsUpdated += EventBinderWrappers.WrapChannelPinsUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildCreateEventHandler)))
            client.GuildCreated += EventBinderWrappers.WrapGuildCreate(handler);
        if (handler.IsAssignableTo(typeof(IGuildUpdateEventHandler)))
            client.GuildUpdated += EventBinderWrappers.WrapGuildUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildDeleteEventHandler)))
            client.GuildDeleted += EventBinderWrappers.WrapGuildDelete(handler);
        if (handler.IsAssignableTo(typeof(IGuildDownloadCompletedEventHandler)))
            client.GuildDownloadCompleted += EventBinderWrappers.WrapGuildDownloadCompleted(handler);
        if (handler.IsAssignableTo(typeof(IGuildEmojisUpdateEventHandler)))
            client.GuildEmojisUpdated += EventBinderWrappers.WrapGuildEmojisUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildStickersUpdateEventHandler)))
            client.GuildStickersUpdated += EventBinderWrappers.WrapGuildStickersUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildIntegrationsUpdateEventHandler)))
            client.GuildIntegrationsUpdated += EventBinderWrappers.WrapGuildIntegrationsUpdate(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventCreateEventHandler)))
            client.ScheduledGuildEventCreated += EventBinderWrappers.WrapScheduledGuildEventCreate(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventUpdateEventHandler)))
            client.ScheduledGuildEventUpdated += EventBinderWrappers.WrapScheduledGuildEventUpdate(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventDeleteEventHandler)))
            client.ScheduledGuildEventDeleted += EventBinderWrappers.WrapScheduledGuildEventDelete(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventCompletedEventHandler)))
            client.ScheduledGuildEventCompleted += EventBinderWrappers.WrapScheduledGuildEventCompleted(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventUserAddEventHandler)))
            client.ScheduledGuildEventUserAdded += EventBinderWrappers.WrapScheduledGuildEventUserAdd(handler);
        if (handler.IsAssignableTo(typeof(IScheduledGuildEventUserRemoveEventHandler)))
            client.ScheduledGuildEventUserRemoved += EventBinderWrappers.WrapScheduledGuildEventUserRemove(handler);
        if (handler.IsAssignableTo(typeof(IGuildBanAddEventHandler)))
            client.GuildBanAdded += EventBinderWrappers.WrapGuildBanAdd(handler);
        if (handler.IsAssignableTo(typeof(IGuildBanRemoveEventHandler)))
            client.GuildBanRemoved += EventBinderWrappers.WrapGuildBanRemove(handler);
        if (handler.IsAssignableTo(typeof(IGuildMemberAddEventHandler)))
            client.GuildMemberAdded += EventBinderWrappers.WrapGuildMemberAdd(handler);
        if (handler.IsAssignableTo(typeof(IGuildMemberRemoveEventHandler)))
            client.GuildMemberRemoved += EventBinderWrappers.WrapGuildMemberRemove(handler);
        if (handler.IsAssignableTo(typeof(IGuildMemberUpdateEventHandler)))
            client.GuildMemberUpdated += EventBinderWrappers.WrapGuildMemberUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildMembersChunkEventHandler)))
            client.GuildMembersChunked += EventBinderWrappers.WrapGuildMembersChunk(handler);
        if (handler.IsAssignableTo(typeof(IGuildRoleCreateEventHandler)))
            client.GuildRoleCreated += EventBinderWrappers.WrapGuildRoleCreate(handler);
        if (handler.IsAssignableTo(typeof(IGuildRoleUpdateEventHandler)))
            client.GuildRoleUpdated += EventBinderWrappers.WrapGuildRoleUpdate(handler);
        if (handler.IsAssignableTo(typeof(IGuildRoleDeleteEventHandler)))
            client.GuildRoleDeleted += EventBinderWrappers.WrapGuildRoleDelete(handler);
        if (handler.IsAssignableTo(typeof(IInviteCreateEventHandler)))
            client.InviteCreated += EventBinderWrappers.WrapInviteCreate(handler);
        if (handler.IsAssignableTo(typeof(IInviteDeleteEventHandler)))
            client.InviteDeleted += EventBinderWrappers.WrapInviteDelete(handler);
        if (handler.IsAssignableTo(typeof(IMessageCreatedEventHandler)))
            client.MessageCreated += EventBinderWrappers.WrapMessageCreate(handler);
        if (handler.IsAssignableTo(typeof(IMessageAcknowledgeEventHandler)))
            client.MessageAcknowledged += EventBinderWrappers.WrapMessageAcknowledge(handler);
        if (handler.IsAssignableTo(typeof(IMessageUpdateEventHandler)))
            client.MessageUpdated += EventBinderWrappers.WrapMessageUpdate(handler);
        if (handler.IsAssignableTo(typeof(IMessageDeleteEventHandler)))
            client.MessageDeleted += EventBinderWrappers.WrapMessageDelete(handler);
        if (handler.IsAssignableTo(typeof(IMessageBulkDeleteEventHandler)))
            client.MessagesBulkDeleted += EventBinderWrappers.WrapMessageBulkDelete(handler);
        if (handler.IsAssignableTo(typeof(IMessageReactionAddEventHandler)))
            client.MessageReactionAdded += EventBinderWrappers.WrapMessageReactionAdd(handler);
        if (handler.IsAssignableTo(typeof(IMessageReactionRemoveEventHandler)))
            client.MessageReactionRemoved += EventBinderWrappers.WrapMessageReactionRemove(handler);
        if (handler.IsAssignableTo(typeof(IMessageReactionsClearEventHandler)))
            client.MessageReactionsCleared += EventBinderWrappers.WrapMessageReactionsClear(handler);
        if (handler.IsAssignableTo(typeof(IMessageReactionRemoveEmojiEventHandler)))
            client.MessageReactionRemovedEmoji += EventBinderWrappers.WrapMessageReactionRemoveEmoji(handler);
        if (handler.IsAssignableTo(typeof(IPresenceUpdateEventHandler)))
            client.PresenceUpdated += EventBinderWrappers.WrapPresenceUpdate(handler);
        if (handler.IsAssignableTo(typeof(IUserSettingsUpdateEventHandler)))
            client.UserSettingsUpdated += EventBinderWrappers.WrapUserSettingsUpdate(handler);
        if (handler.IsAssignableTo(typeof(IUserUpdateEventHandler)))
            client.UserUpdated += EventBinderWrappers.WrapUserUpdate(handler);
        if (handler.IsAssignableTo(typeof(IVoiceStateUpdateEventHandler)))
            client.VoiceStateUpdated += EventBinderWrappers.WrapVoiceStateUpdate(handler);
        if (handler.IsAssignableTo(typeof(IVoiceServerUpdateEventHandler)))
            client.VoiceServerUpdated += EventBinderWrappers.WrapVoiceServerUpdate(handler);
        if (handler.IsAssignableTo(typeof(IThreadCreateEventHandler)))
            client.ThreadCreated += EventBinderWrappers.WrapThreadCreate(handler);
        if (handler.IsAssignableTo(typeof(IThreadUpdateEventHandler)))
            client.ThreadUpdated += EventBinderWrappers.WrapThreadUpdate(handler);
        if (handler.IsAssignableTo(typeof(IThreadDeleteEventHandler)))
            client.ThreadDeleted += EventBinderWrappers.WrapThreadDelete(handler);
        if (handler.IsAssignableTo(typeof(IThreadListSyncEventHandler)))
            client.ThreadListSynced += EventBinderWrappers.WrapThreadListSync(handler);
        if (handler.IsAssignableTo(typeof(IThreadMemberUpdateEventHandler)))
            client.ThreadMemberUpdated += EventBinderWrappers.WrapThreadMemberUpdate(handler);
        if (handler.IsAssignableTo(typeof(IThreadMembersUpdateEventHandler)))
            client.ThreadMembersUpdated += EventBinderWrappers.WrapThreadMembersUpdate(handler);
        if (handler.IsAssignableTo(typeof(IIntegrationCreateEventHandler)))
            client.IntegrationCreated += EventBinderWrappers.WrapIntegrationCreate(handler);
        if (handler.IsAssignableTo(typeof(IIntegrationUpdateEventHandler)))
            client.IntegrationUpdated += EventBinderWrappers.WrapIntegrationUpdate(handler);
        if (handler.IsAssignableTo(typeof(IIntegrationDeleteEventHandler)))
            client.IntegrationDeleted += EventBinderWrappers.WrapIntegrationDelete(handler);
        if (handler.IsAssignableTo(typeof(IStageInstanceCreateEventHandler)))
            client.StageInstanceCreated += EventBinderWrappers.WrapStageInstanceCreate(handler);
        if (handler.IsAssignableTo(typeof(IStageInstanceUpdateEventHandler)))
            client.StageInstanceUpdated += EventBinderWrappers.WrapStageInstanceUpdate(handler);
        if (handler.IsAssignableTo(typeof(IStageInstanceDeleteEventHandler)))
            client.StageInstanceDeleted += EventBinderWrappers.WrapStageInstanceDelete(handler);
        if (handler.IsAssignableTo(typeof(IInteractionCreateEventHandler)))
            client.InteractionCreated += EventBinderWrappers.WrapInteractionCreate(handler);
        if (handler.IsAssignableTo(typeof(IComponentInteractionCreateEventHandler)))
            client.ComponentInteractionCreated += EventBinderWrappers.WrapComponentInteractionCreate(handler);
        if (handler.IsAssignableTo(typeof(IModalSubmitEventHandler)))
            client.ModalSubmitted += EventBinderWrappers.WrapModalSubmit(handler);
        if (handler.IsAssignableTo(typeof(IContextMenuInteractionCreateEventHandler)))
            client.ContextMenuInteractionCreated += EventBinderWrappers.WrapContextMenuInteractionCreate(handler);
        if (handler.IsAssignableTo(typeof(ITypingStartEventHandler)))
            client.TypingStarted += EventBinderWrappers.WrapTypingStart(handler);
        if (handler.IsAssignableTo(typeof(IWebhooksUpdateEventHandler)))
            client.WebhooksUpdated += EventBinderWrappers.WrapWebhooksUpdate(handler);
        if (handler.IsAssignableTo(typeof(IClientErrorEventHandler)))
            client.ClientErrored += EventBinderWrappers.WrapClientError(handler);
    }
}
