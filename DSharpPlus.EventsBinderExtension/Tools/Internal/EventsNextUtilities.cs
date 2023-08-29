using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using DSharpPlus.EventsBinderExtension.Entities;

namespace DSharpPlus.EventsBinderExtension.Tools.Internal;

internal static partial class EventsNextUtilities
{
    public static ImmutableHashSet<Type> HandlerInterfaces = ImmutableHashSet.Create(typeof(ISocketOpenedEventHandler),
        typeof(ISocketClosedEventHandler),
        typeof(IResumedEventHandler),
        typeof(IHeartbeatEventHandler),
        typeof(IChannelCreatedEventHandler),
        typeof(IReadyEventHandler),
        typeof(IZombiedEventHandler),
        typeof(IChannelUpdateEventHandler),
        typeof(IChannelDeleteEventHandler),
        typeof(IDmChannelDeleteEventHandler),
        typeof(IChannelPinsUpdateEventHandler),
        typeof(IGuildCreateEventHandler),
        typeof(IGuildUpdateEventHandler),
        typeof(IGuildDeleteEventHandler),
        typeof(IGuildDownloadCompletedEventHandler),
        typeof(IGuildEmojisUpdateEventHandler),
        typeof(IGuildStickersUpdateEventHandler),
        typeof(IGuildIntegrationsUpdateEventHandler),
        typeof(IScheduledGuildEventCreateEventHandler),
        typeof(IScheduledGuildEventUpdateEventHandler),
        typeof(IScheduledGuildEventDeleteEventHandler),
        typeof(IScheduledGuildEventCompletedEventHandler),
        typeof(IScheduledGuildEventUserAddEventHandler),
        typeof(IScheduledGuildEventUserRemoveEventHandler),
        typeof(IGuildBanAddEventHandler),
        typeof(IGuildBanRemoveEventHandler),
        typeof(IGuildMemberAddEventHandler),
        typeof(IGuildMemberRemoveEventHandler),
        typeof(IGuildMemberUpdateEventHandler),
        typeof(IGuildMembersChunkEventHandler),
        typeof(IGuildRoleCreateEventHandler),
        typeof(IGuildRoleUpdateEventHandler),
        typeof(IGuildRoleDeleteEventHandler),
        typeof(IInviteCreateEventHandler),
        typeof(IInviteDeleteEventHandler),
        typeof(IMessageCreatedEventHandler),
        typeof(IMessageAcknowledgeEventHandler),
        typeof(IMessageUpdateEventHandler),
        typeof(IMessageDeleteEventHandler),
        typeof(IMessageBulkDeleteEventHandler),
        typeof(IMessageReactionAddEventHandler),
        typeof(IMessageReactionRemoveEventHandler),
        typeof(IMessageReactionsClearEventHandler),
        typeof(IMessageReactionRemoveEmojiEventHandler),
        typeof(IPresenceUpdateEventHandler),
        typeof(IUserSettingsUpdateEventHandler),
        typeof(IUserUpdateEventHandler),
        typeof(IVoiceStateUpdateEventHandler),
        typeof(IVoiceServerUpdateEventHandler),
        typeof(IThreadCreateEventHandler),
        typeof(IThreadUpdateEventHandler),
        typeof(IThreadDeleteEventHandler),
        typeof(IThreadListSyncEventHandler),
        typeof(IThreadMemberUpdateEventHandler),
        typeof(IThreadMembersUpdateEventHandler),
        typeof(IIntegrationCreateEventHandler),
        typeof(IIntegrationUpdateEventHandler),
        typeof(IIntegrationDeleteEventHandler),
        typeof(IStageInstanceCreateEventHandler),
        typeof(IStageInstanceUpdateEventHandler),
        typeof(IStageInstanceDeleteEventHandler),
        typeof(IInteractionCreateEventHandler),
        typeof(IComponentInteractionCreateEventHandler),
        typeof(IModalSubmitEventHandler),
        typeof(IContextMenuInteractionCreateEventHandler),
        typeof(ITypingStartEventHandler),
        typeof(IWebhooksUpdateEventHandler),
        typeof(IClientErrorEventHandler)
    );
    public static IEnumerable<Type> GetHandlerTypes(Assembly assembly) => FilterHandlerTypes(assembly.ExportedTypes);
    public static IEnumerable<Type> FilterHandlerTypes(IEnumerable<Type> types) => types.Where(IsValidHandler);

    public static void VerifyHandler(Type handler)
    {
        if (!IsValidHandler(handler, out string reason))
            throw new ArgumentException(reason, nameof(handler));
    }

    public static bool IsValidHandler(Type handler) => IsValidHandler(handler, throwOnNull: true, out string _);
    public static bool IsValidHandler(Type handler, bool throwOnNull) => IsValidHandler(handler, throwOnNull, out string _);
    public static bool IsValidHandler(Type handler, out string reason) => IsValidHandler(handler, true, out reason);
    public static bool IsValidHandler(Type handler, bool throwOnNull, out string reason)
    {
        if (handler == null)
        {
            if (throwOnNull)
                ArgumentNullException.ThrowIfNull(handler);

            reason = "handler type was null";
            return false;
        }

        if (!handler.IsClass)
        {
            reason = $"Type {handler.Name} is not a class implementing {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (handler.IsAbstract)
        {
            reason = $"Type {handler.Name} is abstract, which is not allowed";
            return false;
        }

        if (!handler.IsAssignableTo(typeof(IDiscordEventHandler)))
        {
            reason = $"Type {handler.Name} is not a {nameof(IDiscordEventHandler)}";
            return false;
        }


        if (handler.IsNested)
        {
            reason = $"Type {handler.Name} is nested, which is not allowed";
            return false;
        }
        reason = string.Empty;
        return true;
    }

    public static IEnumerable<Type> GetInterfaces(Type handler) => HandlerInterfaces.Where(handler.IsAssignableTo);
}
