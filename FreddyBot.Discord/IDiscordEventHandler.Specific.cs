using DSharpPlus.EventArgs;
using DSharpPlus;
using System.Threading.Tasks;

namespace FreddyBot.Discord;

public interface ISocketErroredEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<SocketErrorEventArgs>*/
{
    public Task OnSocketErrored(DiscordClient client, SocketErrorEventArgs args);
}
public abstract class SocketErroredEventHandler :DiscordEventHandler<SocketErrorEventArgs>/*, IDiscordEventHandler<SocketErrorEventArgs>*/, ISocketErroredEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, SocketErrorEventArgs args) => OnSocketErrored(client, args);
    public abstract Task OnSocketErrored(DiscordClient client, SocketErrorEventArgs args);
}

public interface ISocketOpenedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<SocketEventArgs>*/
{
    public Task OnSocketOpened(DiscordClient client, SocketEventArgs args);
}
public abstract class SocketOpenedEventHandler :DiscordEventHandler<SocketEventArgs>/*, IDiscordEventHandler<SocketEventArgs>*/, ISocketOpenedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, SocketEventArgs args) => OnSocketOpened(client, args);
    public abstract Task OnSocketOpened(DiscordClient client, SocketEventArgs args);
}

public interface ISocketClosedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<SocketCloseEventArgs>*/
{
    public Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs args);
}
public abstract class SocketClosedEventHandler :DiscordEventHandler<SocketCloseEventArgs>/*, IDiscordEventHandler<SocketCloseEventArgs>*/, ISocketClosedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, SocketCloseEventArgs args) => OnSocketClosed(client, args);
    public abstract Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs args);
}

public interface IReadyEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ReadyEventArgs>*/
{
    public Task OnReady(DiscordClient client, ReadyEventArgs args);
}
public abstract class ReadyEventHandler :DiscordEventHandler<ReadyEventArgs>/*, IDiscordEventHandler<ReadyEventArgs>*/, IReadyEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ReadyEventArgs args) => OnReady(client, args);
    public abstract Task OnReady(DiscordClient client, ReadyEventArgs args);
}

public interface IResumedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ReadyEventArgs>*/
{
    public Task OnResumed(DiscordClient client, ReadyEventArgs args);
}
public abstract class ResumedEventHandler :DiscordEventHandler<ReadyEventArgs>/*, IDiscordEventHandler<ReadyEventArgs>*/, IResumedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ReadyEventArgs args) => OnResumed(client, args);
    public abstract Task OnResumed(DiscordClient client, ReadyEventArgs args);
}

public interface IHeartbeatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<HeartbeatEventArgs>*/
{
    public Task OnHeartbeated(DiscordClient client, HeartbeatEventArgs args);
}
public abstract class HeartbeatedEventHandler :DiscordEventHandler<HeartbeatEventArgs>/*, IDiscordEventHandler<HeartbeatEventArgs>*/, IHeartbeatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, HeartbeatEventArgs args) => OnHeartbeated(client, args);
    public abstract Task OnHeartbeated(DiscordClient client, HeartbeatEventArgs args);
}

public interface IZombiedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ZombiedEventArgs>*/
{
    public Task OnZombied(DiscordClient client, ZombiedEventArgs args);
}
public abstract class ZombiedEventHandler :DiscordEventHandler<ZombiedEventArgs>/*, IDiscordEventHandler<ZombiedEventArgs>*/, IZombiedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ZombiedEventArgs args) => OnZombied(client, args);
    public abstract Task OnZombied(DiscordClient client, ZombiedEventArgs args);
}

public interface IChannelCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ChannelCreateEventArgs>*/
{
    public Task OnChannelCreated(DiscordClient client, ChannelCreateEventArgs args);
}
public abstract class ChannelCreatedEventHandler :DiscordEventHandler<ChannelCreateEventArgs>/*, IDiscordEventHandler<ChannelCreateEventArgs>*/, IChannelCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ChannelCreateEventArgs args) => OnChannelCreated(client, args);
    public abstract Task OnChannelCreated(DiscordClient client, ChannelCreateEventArgs args);
}

public interface IChannelUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ChannelUpdateEventArgs>*/
{
    public Task OnChannelUpdated(DiscordClient client, ChannelUpdateEventArgs args);
}
public abstract class ChannelUpdatedEventHandler :DiscordEventHandler<ChannelUpdateEventArgs>/*, IDiscordEventHandler<ChannelUpdateEventArgs>*/, IChannelUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ChannelUpdateEventArgs args) => OnChannelUpdated(client, args);
    public abstract Task OnChannelUpdated(DiscordClient client, ChannelUpdateEventArgs args);
}

public interface IChannelDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ChannelDeleteEventArgs>*/
{
    public Task OnChannelDeleted(DiscordClient client, ChannelDeleteEventArgs args);
}
public abstract class ChannelDeletedEventHandler :DiscordEventHandler<ChannelDeleteEventArgs>/*, IDiscordEventHandler<ChannelDeleteEventArgs>*/, IChannelDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ChannelDeleteEventArgs args) => OnChannelDeleted(client, args);
    public abstract Task OnChannelDeleted(DiscordClient client, ChannelDeleteEventArgs args);
}

public interface IDmChannelDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<DmChannelDeleteEventArgs>*/
{
    public Task OnDmChannelDeleted(DiscordClient client, DmChannelDeleteEventArgs args);
}
public abstract class DmChannelDeletedEventHandler :DiscordEventHandler<DmChannelDeleteEventArgs>/*, IDiscordEventHandler<DmChannelDeleteEventArgs>*/, IDmChannelDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, DmChannelDeleteEventArgs args) => OnDmChannelDeleted(client, args);
    public abstract Task OnDmChannelDeleted(DiscordClient client, DmChannelDeleteEventArgs args);
}

public interface IChannelPinsUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ChannelPinsUpdateEventArgs>*/
{
    public Task OnChannelPinsUpdated(DiscordClient client, ChannelPinsUpdateEventArgs args);
}
public abstract class ChannelPinsUpdatedEventHandler :DiscordEventHandler<ChannelPinsUpdateEventArgs>/*, IDiscordEventHandler<ChannelPinsUpdateEventArgs>*/, IChannelPinsUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ChannelPinsUpdateEventArgs args) => OnChannelPinsUpdated(client, args);
    public abstract Task OnChannelPinsUpdated(DiscordClient client, ChannelPinsUpdateEventArgs args);
}

public interface IGuildCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildCreateEventArgs>*/
{
    public Task OnGuildCreated(DiscordClient client, GuildCreateEventArgs args);
}
public abstract class GuildCreatedEventHandler :DiscordEventHandler<GuildCreateEventArgs>/*, IDiscordEventHandler<GuildCreateEventArgs>*/, IGuildCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildCreateEventArgs args) => OnGuildCreated(client, args);
    public abstract Task OnGuildCreated(DiscordClient client, GuildCreateEventArgs args);
}

public interface IGuildAvailableEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildCreateEventArgs>*/
{
    public Task OnGuildAvailable(DiscordClient client, GuildCreateEventArgs args);
}
public abstract class GuildAvailableEventHandler :DiscordEventHandler<GuildCreateEventArgs>/*, IDiscordEventHandler<GuildCreateEventArgs>*/, IGuildAvailableEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildCreateEventArgs args) => OnGuildAvailable(client, args);
    public abstract Task OnGuildAvailable(DiscordClient client, GuildCreateEventArgs args);
}

public interface IGuildUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildUpdateEventArgs>*/
{
    public Task OnGuildUpdated(DiscordClient client, GuildUpdateEventArgs args);
}
public abstract class GuildUpdatedEventHandler :DiscordEventHandler<GuildUpdateEventArgs>/*, IDiscordEventHandler<GuildUpdateEventArgs>*/, IGuildUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildUpdateEventArgs args) => OnGuildUpdated(client, args);
    public abstract Task OnGuildUpdated(DiscordClient client, GuildUpdateEventArgs args);
}

public interface IGuildDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildDeleteEventArgs>*/
{
    public Task OnGuildDeleted(DiscordClient client, GuildDeleteEventArgs args);
}
public abstract class GuildDeletedEventHandler :DiscordEventHandler<GuildDeleteEventArgs>/*, IDiscordEventHandler<GuildDeleteEventArgs>*/, IGuildDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildDeleteEventArgs args) => OnGuildDeleted(client, args);
    public abstract Task OnGuildDeleted(DiscordClient client, GuildDeleteEventArgs args);
}

public interface IGuildUnavailableEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildDeleteEventArgs>*/
{
    public Task OnGuildUnavailable(DiscordClient client, GuildDeleteEventArgs args);
}
public abstract class GuildUnavailableEventHandler :DiscordEventHandler<GuildDeleteEventArgs>/*, IDiscordEventHandler<GuildDeleteEventArgs>*/, IGuildUnavailableEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildDeleteEventArgs args) => OnGuildUnavailable(client, args);
    public abstract Task OnGuildUnavailable(DiscordClient client, GuildDeleteEventArgs args);
}

public interface IGuildDownloadCompletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildDownloadCompletedEventArgs>*/
{
    public Task OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args);
}
public abstract class GuildDownloadCompletedEventHandler :DiscordEventHandler<GuildDownloadCompletedEventArgs>/*, IDiscordEventHandler<GuildDownloadCompletedEventArgs>*/, IGuildDownloadCompletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildDownloadCompletedEventArgs args) => OnGuildDownloadCompleted(client, args);
    public abstract Task OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args);
}

public interface IGuildEmojisUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildEmojisUpdateEventArgs>*/
{
    public Task OnGuildEmojisUpdated(DiscordClient client, GuildEmojisUpdateEventArgs args);
}
public abstract class GuildEmojisUpdatedEventHandler :DiscordEventHandler<GuildEmojisUpdateEventArgs>/*, IDiscordEventHandler<GuildEmojisUpdateEventArgs>*/, IGuildEmojisUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildEmojisUpdateEventArgs args) => OnGuildEmojisUpdated(client, args);
    public abstract Task OnGuildEmojisUpdated(DiscordClient client, GuildEmojisUpdateEventArgs args);
}

public interface IGuildStickersUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildStickersUpdateEventArgs>*/
{
    public Task OnGuildStickersUpdated(DiscordClient client, GuildStickersUpdateEventArgs args);
}
public abstract class GuildStickersUpdatedEventHandler :DiscordEventHandler<GuildStickersUpdateEventArgs>/*, IDiscordEventHandler<GuildStickersUpdateEventArgs>*/, IGuildStickersUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildStickersUpdateEventArgs args) => OnGuildStickersUpdated(client, args);
    public abstract Task OnGuildStickersUpdated(DiscordClient client, GuildStickersUpdateEventArgs args);
}

public interface IGuildIntegrationsUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildIntegrationsUpdateEventArgs>*/
{
    public Task OnGuildIntegrationsUpdated(DiscordClient client, GuildIntegrationsUpdateEventArgs args);
}
public abstract class GuildIntegrationsUpdatedEventHandler :DiscordEventHandler<GuildIntegrationsUpdateEventArgs>/*, IDiscordEventHandler<GuildIntegrationsUpdateEventArgs>*/, IGuildIntegrationsUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildIntegrationsUpdateEventArgs args) => OnGuildIntegrationsUpdated(client, args);
    public abstract Task OnGuildIntegrationsUpdated(DiscordClient client, GuildIntegrationsUpdateEventArgs args);
}

public interface IScheduledGuildEventCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventCreateEventArgs>*/
{
    public Task OnScheduledGuildEventCreated(DiscordClient client, ScheduledGuildEventCreateEventArgs args);
}
public abstract class ScheduledGuildEventCreatedEventHandler :DiscordEventHandler<ScheduledGuildEventCreateEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventCreateEventArgs>*/, IScheduledGuildEventCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventCreateEventArgs args) => OnScheduledGuildEventCreated(client, args);
    public abstract Task OnScheduledGuildEventCreated(DiscordClient client, ScheduledGuildEventCreateEventArgs args);
}

public interface IScheduledGuildEventUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventUpdateEventArgs>*/
{
    public Task OnScheduledGuildEventUpdated(DiscordClient client, ScheduledGuildEventUpdateEventArgs args);
}
public abstract class ScheduledGuildEventUpdatedEventHandler :DiscordEventHandler<ScheduledGuildEventUpdateEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventUpdateEventArgs>*/, IScheduledGuildEventUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUpdateEventArgs args) => OnScheduledGuildEventUpdated(client, args);
    public abstract Task OnScheduledGuildEventUpdated(DiscordClient client, ScheduledGuildEventUpdateEventArgs args);
}

public interface IScheduledGuildEventDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventDeleteEventArgs>*/
{
    public Task OnScheduledGuildEventDeleted(DiscordClient client, ScheduledGuildEventDeleteEventArgs args);
}
public abstract class ScheduledGuildEventDeletedEventHandler :DiscordEventHandler<ScheduledGuildEventDeleteEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventDeleteEventArgs>*/, IScheduledGuildEventDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventDeleteEventArgs args) => OnScheduledGuildEventDeleted(client, args);
    public abstract Task OnScheduledGuildEventDeleted(DiscordClient client, ScheduledGuildEventDeleteEventArgs args);
}

public interface IScheduledGuildEventCompletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventCompletedEventArgs>*/
{
    public Task OnScheduledGuildEventCompleted(DiscordClient client, ScheduledGuildEventCompletedEventArgs args);
}
public abstract class ScheduledGuildEventCompletedEventHandler :DiscordEventHandler<ScheduledGuildEventCompletedEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventCompletedEventArgs>*/, IScheduledGuildEventCompletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventCompletedEventArgs args) => OnScheduledGuildEventCompleted(client, args);
    public abstract Task OnScheduledGuildEventCompleted(DiscordClient client, ScheduledGuildEventCompletedEventArgs args);
}

public interface IScheduledGuildEventUserAddedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventUserAddEventArgs>*/
{
    public Task OnScheduledGuildEventUserAdded(DiscordClient client, ScheduledGuildEventUserAddEventArgs args);
}
public abstract class ScheduledGuildEventUserAddedEventHandler :DiscordEventHandler<ScheduledGuildEventUserAddEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventUserAddEventArgs>*/, IScheduledGuildEventUserAddedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUserAddEventArgs args) => OnScheduledGuildEventUserAdded(client, args);
    public abstract Task OnScheduledGuildEventUserAdded(DiscordClient client, ScheduledGuildEventUserAddEventArgs args);
}

public interface IScheduledGuildEventUserRemovedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ScheduledGuildEventUserRemoveEventArgs>*/
{
    public Task OnScheduledGuildEventUserRemoved(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args);
}
public abstract class ScheduledGuildEventUserRemovedEventHandler :DiscordEventHandler<ScheduledGuildEventUserRemoveEventArgs>/*, IDiscordEventHandler<ScheduledGuildEventUserRemoveEventArgs>*/, IScheduledGuildEventUserRemovedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args) => OnScheduledGuildEventUserRemoved(client, args);
    public abstract Task OnScheduledGuildEventUserRemoved(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args);
}

public interface IGuildBanAddedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildBanAddEventArgs>*/
{
    public Task OnGuildBanAdded(DiscordClient client, GuildBanAddEventArgs args);
}
public abstract class GuildBanAddedEventHandler :DiscordEventHandler<GuildBanAddEventArgs>/*, IDiscordEventHandler<GuildBanAddEventArgs>*/, IGuildBanAddedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildBanAddEventArgs args) => OnGuildBanAdded(client, args);
    public abstract Task OnGuildBanAdded(DiscordClient client, GuildBanAddEventArgs args);
}

public interface IGuildBanRemovedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildBanRemoveEventArgs>*/
{
    public Task OnGuildBanRemoved(DiscordClient client, GuildBanRemoveEventArgs args);
}
public abstract class GuildBanRemovedEventHandler :DiscordEventHandler<GuildBanRemoveEventArgs>/*, IDiscordEventHandler<GuildBanRemoveEventArgs>*/, IGuildBanRemovedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildBanRemoveEventArgs args) => OnGuildBanRemoved(client, args);
    public abstract Task OnGuildBanRemoved(DiscordClient client, GuildBanRemoveEventArgs args);
}

public interface IGuildMemberAddedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildMemberAddEventArgs>*/
{
    public Task OnGuildMemberAdded(DiscordClient client, GuildMemberAddEventArgs args);
}
public abstract class GuildMemberAddedEventHandler :DiscordEventHandler<GuildMemberAddEventArgs>/*, IDiscordEventHandler<GuildMemberAddEventArgs>*/, IGuildMemberAddedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildMemberAddEventArgs args) => OnGuildMemberAdded(client, args);
    public abstract Task OnGuildMemberAdded(DiscordClient client, GuildMemberAddEventArgs args);
}

public interface IGuildMemberRemovedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildMemberRemoveEventArgs>*/
{
    public Task OnGuildMemberRemoved(DiscordClient client, GuildMemberRemoveEventArgs args);
}
public abstract class GuildMemberRemovedEventHandler :DiscordEventHandler<GuildMemberRemoveEventArgs>/*, IDiscordEventHandler<GuildMemberRemoveEventArgs>*/, IGuildMemberRemovedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildMemberRemoveEventArgs args) => OnGuildMemberRemoved(client, args);
    public abstract Task OnGuildMemberRemoved(DiscordClient client, GuildMemberRemoveEventArgs args);
}

public interface IGuildMemberUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildMemberUpdateEventArgs>*/
{
    public Task OnGuildMemberUpdated(DiscordClient client, GuildMemberUpdateEventArgs args);
}
public abstract class GuildMemberUpdatedEventHandler :DiscordEventHandler<GuildMemberUpdateEventArgs>/*, IDiscordEventHandler<GuildMemberUpdateEventArgs>*/, IGuildMemberUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildMemberUpdateEventArgs args) => OnGuildMemberUpdated(client, args);
    public abstract Task OnGuildMemberUpdated(DiscordClient client, GuildMemberUpdateEventArgs args);
}

public interface IGuildMembersChunkedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildMembersChunkEventArgs>*/
{
    public Task OnGuildMembersChunked(DiscordClient client, GuildMembersChunkEventArgs args);
}
public abstract class GuildMembersChunkedEventHandler :DiscordEventHandler<GuildMembersChunkEventArgs>/*, IDiscordEventHandler<GuildMembersChunkEventArgs>*/, IGuildMembersChunkedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildMembersChunkEventArgs args) => OnGuildMembersChunked(client, args);
    public abstract Task OnGuildMembersChunked(DiscordClient client, GuildMembersChunkEventArgs args);
}

public interface IGuildRoleCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildRoleCreateEventArgs>*/
{
    public Task OnGuildRoleCreated(DiscordClient client, GuildRoleCreateEventArgs args);
}
public abstract class GuildRoleCreatedEventHandler :DiscordEventHandler<GuildRoleCreateEventArgs>/*, IDiscordEventHandler<GuildRoleCreateEventArgs>*/, IGuildRoleCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildRoleCreateEventArgs args) => OnGuildRoleCreated(client, args);
    public abstract Task OnGuildRoleCreated(DiscordClient client, GuildRoleCreateEventArgs args);
}

public interface IGuildRoleUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildRoleUpdateEventArgs>*/
{
    public Task OnGuildRoleUpdated(DiscordClient client, GuildRoleUpdateEventArgs args);
}
public abstract class GuildRoleUpdatedEventHandler :DiscordEventHandler<GuildRoleUpdateEventArgs>/*, IDiscordEventHandler<GuildRoleUpdateEventArgs>*/, IGuildRoleUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildRoleUpdateEventArgs args) => OnGuildRoleUpdated(client, args);
    public abstract Task OnGuildRoleUpdated(DiscordClient client, GuildRoleUpdateEventArgs args);
}

public interface IGuildRoleDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<GuildRoleDeleteEventArgs>*/
{
    public Task OnGuildRoleDeleted(DiscordClient client, GuildRoleDeleteEventArgs args);
}
public abstract class GuildRoleDeletedEventHandler :DiscordEventHandler<GuildRoleDeleteEventArgs>/*, IDiscordEventHandler<GuildRoleDeleteEventArgs>*/, IGuildRoleDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, GuildRoleDeleteEventArgs args) => OnGuildRoleDeleted(client, args);
    public abstract Task OnGuildRoleDeleted(DiscordClient client, GuildRoleDeleteEventArgs args);
}

public interface IInviteCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<InviteCreateEventArgs>*/
{
    public Task OnInviteCreated(DiscordClient client, InviteCreateEventArgs args);
}
public abstract class InviteCreatedEventHandler :DiscordEventHandler<InviteCreateEventArgs>/*, IDiscordEventHandler<InviteCreateEventArgs>*/, IInviteCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, InviteCreateEventArgs args) => OnInviteCreated(client, args);
    public abstract Task OnInviteCreated(DiscordClient client, InviteCreateEventArgs args);
}

public interface IInviteDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<InviteDeleteEventArgs>*/
{
    public Task OnInviteDeleted(DiscordClient client, InviteDeleteEventArgs args);
}
public abstract class InviteDeletedEventHandler :DiscordEventHandler<InviteDeleteEventArgs>/*, IDiscordEventHandler<InviteDeleteEventArgs>*/, IInviteDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, InviteDeleteEventArgs args) => OnInviteDeleted(client, args);
    public abstract Task OnInviteDeleted(DiscordClient client, InviteDeleteEventArgs args);
}

public interface IMessageCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageCreateEventArgs>*/
{
    public Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args);
}
public abstract class MessageCreatedEventHandler :DiscordEventHandler<MessageCreateEventArgs>/*, IDiscordEventHandler<MessageCreateEventArgs>*/, IMessageCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageCreateEventArgs args) => OnMessageCreated(client, args);
    public abstract Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args);
}

public interface IMessageAcknowledgedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageAcknowledgeEventArgs>*/
{
    public Task OnMessageAcknowledged(DiscordClient client, MessageAcknowledgeEventArgs args);
}
public abstract class MessageAcknowledgedEventHandler :DiscordEventHandler<MessageAcknowledgeEventArgs>/*, IDiscordEventHandler<MessageAcknowledgeEventArgs>*/, IMessageAcknowledgedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageAcknowledgeEventArgs args) => OnMessageAcknowledged(client, args);
    public abstract Task OnMessageAcknowledged(DiscordClient client, MessageAcknowledgeEventArgs args);
}

public interface IMessageUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageUpdateEventArgs>*/
{
    public Task OnMessageUpdated(DiscordClient client, MessageUpdateEventArgs args);
}
public abstract class MessageUpdatedEventHandler :DiscordEventHandler<MessageUpdateEventArgs>/*, IDiscordEventHandler<MessageUpdateEventArgs>*/, IMessageUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageUpdateEventArgs args) => OnMessageUpdated(client, args);
    public abstract Task OnMessageUpdated(DiscordClient client, MessageUpdateEventArgs args);
}

public interface IMessageDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageDeleteEventArgs>*/
{
    public Task OnMessageDeleted(DiscordClient client, MessageDeleteEventArgs args);
}
public abstract class MessageDeletedEventHandler :DiscordEventHandler<MessageDeleteEventArgs>/*, IDiscordEventHandler<MessageDeleteEventArgs>*/, IMessageDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageDeleteEventArgs args) => OnMessageDeleted(client, args);
    public abstract Task OnMessageDeleted(DiscordClient client, MessageDeleteEventArgs args);
}

public interface IMessagesBulkDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageBulkDeleteEventArgs>*/
{
    public Task OnMessagesBulkDeleted(DiscordClient client, MessageBulkDeleteEventArgs args);
}
public abstract class MessagesBulkDeletedEventHandler :DiscordEventHandler<MessageBulkDeleteEventArgs>/*, IDiscordEventHandler<MessageBulkDeleteEventArgs>*/, IMessagesBulkDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageBulkDeleteEventArgs args) => OnMessagesBulkDeleted(client, args);
    public abstract Task OnMessagesBulkDeleted(DiscordClient client, MessageBulkDeleteEventArgs args);
}

public interface IMessageReactionAddedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageReactionAddEventArgs>*/
{
    public Task OnMessageReactionAdded(DiscordClient client, MessageReactionAddEventArgs args);
}
public abstract class MessageReactionAddedEventHandler :DiscordEventHandler<MessageReactionAddEventArgs>/*, IDiscordEventHandler<MessageReactionAddEventArgs>*/, IMessageReactionAddedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageReactionAddEventArgs args) => OnMessageReactionAdded(client, args);
    public abstract Task OnMessageReactionAdded(DiscordClient client, MessageReactionAddEventArgs args);
}

public interface IMessageReactionRemovedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageReactionRemoveEventArgs>*/
{
    public Task OnMessageReactionRemoved(DiscordClient client, MessageReactionRemoveEventArgs args);
}
public abstract class MessageReactionRemovedEventHandler :DiscordEventHandler<MessageReactionRemoveEventArgs>/*, IDiscordEventHandler<MessageReactionRemoveEventArgs>*/, IMessageReactionRemovedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageReactionRemoveEventArgs args) => OnMessageReactionRemoved(client, args);
    public abstract Task OnMessageReactionRemoved(DiscordClient client, MessageReactionRemoveEventArgs args);
}

public interface IMessageReactionsClearedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageReactionsClearEventArgs>*/
{
    public Task OnMessageReactionsCleared(DiscordClient client, MessageReactionsClearEventArgs args);
}
public abstract class MessageReactionsClearedEventHandler :DiscordEventHandler<MessageReactionsClearEventArgs>/*, IDiscordEventHandler<MessageReactionsClearEventArgs>*/, IMessageReactionsClearedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageReactionsClearEventArgs args) => OnMessageReactionsCleared(client, args);
    public abstract Task OnMessageReactionsCleared(DiscordClient client, MessageReactionsClearEventArgs args);
}

public interface IMessageReactionRemovedEmojiEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<MessageReactionRemoveEmojiEventArgs>*/
{
    public Task OnMessageReactionRemovedEmoji(DiscordClient client, MessageReactionRemoveEmojiEventArgs args);
}
public abstract class MessageReactionRemovedEmojiEventHandler :DiscordEventHandler<MessageReactionRemoveEmojiEventArgs>/*, IDiscordEventHandler<MessageReactionRemoveEmojiEventArgs>*/, IMessageReactionRemovedEmojiEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, MessageReactionRemoveEmojiEventArgs args) => OnMessageReactionRemovedEmoji(client, args);
    public abstract Task OnMessageReactionRemovedEmoji(DiscordClient client, MessageReactionRemoveEmojiEventArgs args);
}

public interface IPresenceUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<PresenceUpdateEventArgs>*/
{
    public Task OnPresenceUpdated(DiscordClient client, PresenceUpdateEventArgs args);
}
public abstract class PresenceUpdatedEventHandler :DiscordEventHandler<PresenceUpdateEventArgs>/*, IDiscordEventHandler<PresenceUpdateEventArgs>*/, IPresenceUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, PresenceUpdateEventArgs args) => OnPresenceUpdated(client, args);
    public abstract Task OnPresenceUpdated(DiscordClient client, PresenceUpdateEventArgs args);
}

public interface IUserSettingsUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<UserSettingsUpdateEventArgs>*/
{
    public Task OnUserSettingsUpdated(DiscordClient client, UserSettingsUpdateEventArgs args);
}
public abstract class UserSettingsUpdatedEventHandler :DiscordEventHandler<UserSettingsUpdateEventArgs>/*, IDiscordEventHandler<UserSettingsUpdateEventArgs>*/, IUserSettingsUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, UserSettingsUpdateEventArgs args) => OnUserSettingsUpdated(client, args);
    public abstract Task OnUserSettingsUpdated(DiscordClient client, UserSettingsUpdateEventArgs args);
}

public interface IUserUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<UserUpdateEventArgs>*/
{
    public Task OnUserUpdated(DiscordClient client, UserUpdateEventArgs args);
}
public abstract class UserUpdatedEventHandler :DiscordEventHandler<UserUpdateEventArgs>/*, IDiscordEventHandler<UserUpdateEventArgs>*/, IUserUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, UserUpdateEventArgs args) => OnUserUpdated(client, args);
    public abstract Task OnUserUpdated(DiscordClient client, UserUpdateEventArgs args);
}

public interface IVoiceStateUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<VoiceStateUpdateEventArgs>*/
{
    public Task OnVoiceStateUpdated(DiscordClient client, VoiceStateUpdateEventArgs args);
}
public abstract class VoiceStateUpdatedEventHandler :DiscordEventHandler<VoiceStateUpdateEventArgs>/*, IDiscordEventHandler<VoiceStateUpdateEventArgs>*/, IVoiceStateUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, VoiceStateUpdateEventArgs args) => OnVoiceStateUpdated(client, args);
    public abstract Task OnVoiceStateUpdated(DiscordClient client, VoiceStateUpdateEventArgs args);
}

public interface IVoiceServerUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<VoiceServerUpdateEventArgs>*/
{
    public Task OnVoiceServerUpdated(DiscordClient client, VoiceServerUpdateEventArgs args);
}
public abstract class VoiceServerUpdatedEventHandler :DiscordEventHandler<VoiceServerUpdateEventArgs>/*, IDiscordEventHandler<VoiceServerUpdateEventArgs>*/, IVoiceServerUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, VoiceServerUpdateEventArgs args) => OnVoiceServerUpdated(client, args);
    public abstract Task OnVoiceServerUpdated(DiscordClient client, VoiceServerUpdateEventArgs args);
}

public interface IThreadCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadCreateEventArgs>*/
{
    public Task OnThreadCreated(DiscordClient client, ThreadCreateEventArgs args);
}
public abstract class ThreadCreatedEventHandler :DiscordEventHandler<ThreadCreateEventArgs>/*, IDiscordEventHandler<ThreadCreateEventArgs>*/, IThreadCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadCreateEventArgs args) => OnThreadCreated(client, args);
    public abstract Task OnThreadCreated(DiscordClient client, ThreadCreateEventArgs args);
}

public interface IThreadUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadUpdateEventArgs>*/
{
    public Task OnThreadUpdated(DiscordClient client, ThreadUpdateEventArgs args);
}
public abstract class ThreadUpdatedEventHandler :DiscordEventHandler<ThreadUpdateEventArgs>/*, IDiscordEventHandler<ThreadUpdateEventArgs>*/, IThreadUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadUpdateEventArgs args) => OnThreadUpdated(client, args);
    public abstract Task OnThreadUpdated(DiscordClient client, ThreadUpdateEventArgs args);
}

public interface IThreadDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadDeleteEventArgs>*/
{
    public Task OnThreadDeleted(DiscordClient client, ThreadDeleteEventArgs args);
}
public abstract class ThreadDeletedEventHandler :DiscordEventHandler<ThreadDeleteEventArgs>/*, IDiscordEventHandler<ThreadDeleteEventArgs>*/, IThreadDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadDeleteEventArgs args) => OnThreadDeleted(client, args);
    public abstract Task OnThreadDeleted(DiscordClient client, ThreadDeleteEventArgs args);
}

public interface IThreadListSyncedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadListSyncEventArgs>*/
{
    public Task OnThreadListSynced(DiscordClient client, ThreadListSyncEventArgs args);
}
public abstract class ThreadListSyncedEventHandler :DiscordEventHandler<ThreadListSyncEventArgs>/*, IDiscordEventHandler<ThreadListSyncEventArgs>*/, IThreadListSyncedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadListSyncEventArgs args) => OnThreadListSynced(client, args);
    public abstract Task OnThreadListSynced(DiscordClient client, ThreadListSyncEventArgs args);
}

public interface IThreadMemberUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadMemberUpdateEventArgs>*/
{
    public Task OnThreadMemberUpdated(DiscordClient client, ThreadMemberUpdateEventArgs args);
}
public abstract class ThreadMemberUpdatedEventHandler :DiscordEventHandler<ThreadMemberUpdateEventArgs>/*, IDiscordEventHandler<ThreadMemberUpdateEventArgs>*/, IThreadMemberUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadMemberUpdateEventArgs args) => OnThreadMemberUpdated(client, args);
    public abstract Task OnThreadMemberUpdated(DiscordClient client, ThreadMemberUpdateEventArgs args);
}

public interface IThreadMembersUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ThreadMembersUpdateEventArgs>*/
{
    public Task OnThreadMembersUpdated(DiscordClient client, ThreadMembersUpdateEventArgs args);
}
public abstract class ThreadMembersUpdatedEventHandler :DiscordEventHandler<ThreadMembersUpdateEventArgs>/*, IDiscordEventHandler<ThreadMembersUpdateEventArgs>*/, IThreadMembersUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ThreadMembersUpdateEventArgs args) => OnThreadMembersUpdated(client, args);
    public abstract Task OnThreadMembersUpdated(DiscordClient client, ThreadMembersUpdateEventArgs args);
}
#if obselete
public interface IApplicationCommandCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/
{
    public Task OnApplicationCommandCreated(DiscordClient client, ApplicationCommandEventArgs args);
}
public abstract class ApplicationCommandCreatedEventHandler :DiscordEventHandler<ApplicationCommandEventArgs>/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/, IApplicationCommandCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ApplicationCommandEventArgs args) => OnApplicationCommandCreated(client, args);
    public abstract Task OnApplicationCommandCreated(DiscordClient client, ApplicationCommandEventArgs args);
}

public interface IApplicationCommandUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/
{
    public Task OnApplicationCommandUpdated(DiscordClient client, ApplicationCommandEventArgs args);
}
public abstract class ApplicationCommandUpdatedEventHandler :DiscordEventHandler<ApplicationCommandEventArgs>/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/, IApplicationCommandUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ApplicationCommandEventArgs args) => OnApplicationCommandUpdated(client, args);
    public abstract Task OnApplicationCommandUpdated(DiscordClient client, ApplicationCommandEventArgs args);
}

public interface IApplicationCommandDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/
{
    public Task OnApplicationCommandDeleted(DiscordClient client, ApplicationCommandEventArgs args);
}
public abstract class ApplicationCommandDeletedEventHandler :DiscordEventHandler<ApplicationCommandEventArgs>/*, IDiscordEventHandler<ApplicationCommandEventArgs>*/, IApplicationCommandDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ApplicationCommandEventArgs args) => OnApplicationCommandDeleted(client, args);
    public abstract Task OnApplicationCommandDeleted(DiscordClient client, ApplicationCommandEventArgs args);
}

public interface IApplicationCommandPermissionsUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ApplicationCommandPermissionsUpdatedEventArgs>*/
{
    public Task OnApplicationCommandPermissionsUpdated(DiscordClient client, ApplicationCommandPermissionsUpdatedEventArgs args);
}
public abstract class ApplicationCommandPermissionsUpdatedEventHandler :DiscordEventHandler<ApplicationCommandPermissionsUpdatedEventArgs>/*, IDiscordEventHandler<ApplicationCommandPermissionsUpdatedEventArgs>*/, IApplicationCommandPermissionsUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ApplicationCommandPermissionsUpdatedEventArgs args) => OnApplicationCommandPermissionsUpdated(client, args);
    public abstract Task OnApplicationCommandPermissionsUpdated(DiscordClient client, ApplicationCommandPermissionsUpdatedEventArgs args);
}
#endif
public interface IIntegrationCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<IntegrationCreateEventArgs>*/
{
    public Task OnIntegrationCreated(DiscordClient client, IntegrationCreateEventArgs args);
}
public abstract class IntegrationCreatedEventHandler :DiscordEventHandler<IntegrationCreateEventArgs>/*, IDiscordEventHandler<IntegrationCreateEventArgs>*/, IIntegrationCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, IntegrationCreateEventArgs args) => OnIntegrationCreated(client, args);
    public abstract Task OnIntegrationCreated(DiscordClient client, IntegrationCreateEventArgs args);
}

public interface IIntegrationUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<IntegrationUpdateEventArgs>*/
{
    public Task OnIntegrationUpdated(DiscordClient client, IntegrationUpdateEventArgs args);
}
public abstract class IntegrationUpdatedEventHandler :DiscordEventHandler<IntegrationUpdateEventArgs>/*, IDiscordEventHandler<IntegrationUpdateEventArgs>*/, IIntegrationUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, IntegrationUpdateEventArgs args) => OnIntegrationUpdated(client, args);
    public abstract Task OnIntegrationUpdated(DiscordClient client, IntegrationUpdateEventArgs args);
}

public interface IIntegrationDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<IntegrationDeleteEventArgs>*/
{
    public Task OnIntegrationDeleted(DiscordClient client, IntegrationDeleteEventArgs args);
}
public abstract class IntegrationDeletedEventHandler :DiscordEventHandler<IntegrationDeleteEventArgs>/*, IDiscordEventHandler<IntegrationDeleteEventArgs>*/, IIntegrationDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, IntegrationDeleteEventArgs args) => OnIntegrationDeleted(client, args);
    public abstract Task OnIntegrationDeleted(DiscordClient client, IntegrationDeleteEventArgs args);
}

public interface IStageInstanceCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<StageInstanceCreateEventArgs>*/
{
    public Task OnStageInstanceCreated(DiscordClient client, StageInstanceCreateEventArgs args);
}
public abstract class StageInstanceCreatedEventHandler :DiscordEventHandler<StageInstanceCreateEventArgs>/*, IDiscordEventHandler<StageInstanceCreateEventArgs>*/, IStageInstanceCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, StageInstanceCreateEventArgs args) => OnStageInstanceCreated(client, args);
    public abstract Task OnStageInstanceCreated(DiscordClient client, StageInstanceCreateEventArgs args);
}

public interface IStageInstanceUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<StageInstanceUpdateEventArgs>*/
{
    public Task OnStageInstanceUpdated(DiscordClient client, StageInstanceUpdateEventArgs args);
}
public abstract class StageInstanceUpdatedEventHandler :DiscordEventHandler<StageInstanceUpdateEventArgs>/*, IDiscordEventHandler<StageInstanceUpdateEventArgs>*/, IStageInstanceUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, StageInstanceUpdateEventArgs args) => OnStageInstanceUpdated(client, args);
    public abstract Task OnStageInstanceUpdated(DiscordClient client, StageInstanceUpdateEventArgs args);
}

public interface IStageInstanceDeletedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<StageInstanceDeleteEventArgs>*/
{
    public Task OnStageInstanceDeleted(DiscordClient client, StageInstanceDeleteEventArgs args);
}
public abstract class StageInstanceDeletedEventHandler :DiscordEventHandler<StageInstanceDeleteEventArgs>/*, IDiscordEventHandler<StageInstanceDeleteEventArgs>*/, IStageInstanceDeletedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, StageInstanceDeleteEventArgs args) => OnStageInstanceDeleted(client, args);
    public abstract Task OnStageInstanceDeleted(DiscordClient client, StageInstanceDeleteEventArgs args);
}

public interface IInteractionCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<InteractionCreateEventArgs>*/
{
    public Task OnInteractionCreated(DiscordClient client, InteractionCreateEventArgs args);
}
public abstract class InteractionCreatedEventHandler :DiscordEventHandler<InteractionCreateEventArgs>/*, IDiscordEventHandler<InteractionCreateEventArgs>*/, IInteractionCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, InteractionCreateEventArgs args) => OnInteractionCreated(client, args);
    public abstract Task OnInteractionCreated(DiscordClient client, InteractionCreateEventArgs args);
}

public interface IComponentInteractionCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ComponentInteractionCreateEventArgs>*/
{
    public Task OnComponentInteractionCreated(DiscordClient client, ComponentInteractionCreateEventArgs args);
}
public abstract class ComponentInteractionCreatedEventHandler :DiscordEventHandler<ComponentInteractionCreateEventArgs>/*, IDiscordEventHandler<ComponentInteractionCreateEventArgs>*/, IComponentInteractionCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ComponentInteractionCreateEventArgs args) => OnComponentInteractionCreated(client, args);
    public abstract Task OnComponentInteractionCreated(DiscordClient client, ComponentInteractionCreateEventArgs args);
}

public interface IModalSubmittedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ModalSubmitEventArgs>*/
{
    public Task OnModalSubmitted(DiscordClient client, ModalSubmitEventArgs args);
}
public abstract class ModalSubmittedEventHandler :DiscordEventHandler<ModalSubmitEventArgs>/*, IDiscordEventHandler<ModalSubmitEventArgs>*/, IModalSubmittedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ModalSubmitEventArgs args) => OnModalSubmitted(client, args);
    public abstract Task OnModalSubmitted(DiscordClient client, ModalSubmitEventArgs args);
}

public interface IContextMenuInteractionCreatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ContextMenuInteractionCreateEventArgs>*/
{
    public Task OnContextMenuInteractionCreated(DiscordClient client, ContextMenuInteractionCreateEventArgs args);
}
public abstract class ContextMenuInteractionCreatedEventHandler :DiscordEventHandler<ContextMenuInteractionCreateEventArgs>/*, IDiscordEventHandler<ContextMenuInteractionCreateEventArgs>*/, IContextMenuInteractionCreatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ContextMenuInteractionCreateEventArgs args) => OnContextMenuInteractionCreated(client, args);
    public abstract Task OnContextMenuInteractionCreated(DiscordClient client, ContextMenuInteractionCreateEventArgs args);
}

public interface ITypingStartedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<TypingStartEventArgs>*/
{
    public Task OnTypingStarted(DiscordClient client, TypingStartEventArgs args);
}
public abstract class TypingStartedEventHandler :DiscordEventHandler<TypingStartEventArgs>/*, IDiscordEventHandler<TypingStartEventArgs>*/, ITypingStartedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, TypingStartEventArgs args) => OnTypingStarted(client, args);
    public abstract Task OnTypingStarted(DiscordClient client, TypingStartEventArgs args);
}

public interface IUnknownEventEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<UnknownEventArgs>*/
{
    public Task OnUnknownEvent(DiscordClient client, UnknownEventArgs args);
}
public abstract class UnknownEventEventHandler :DiscordEventHandler<UnknownEventArgs>/*, IDiscordEventHandler<UnknownEventArgs>*/, IUnknownEventEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, UnknownEventArgs args) => OnUnknownEvent(client, args);
    public abstract Task OnUnknownEvent(DiscordClient client, UnknownEventArgs args);
}

public interface IWebhooksUpdatedEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<WebhooksUpdateEventArgs>*/
{
    public Task OnWebhooksUpdated(DiscordClient client, WebhooksUpdateEventArgs args);
}
public abstract class WebhooksUpdatedEventHandler :DiscordEventHandler<WebhooksUpdateEventArgs>/*, IDiscordEventHandler<WebhooksUpdateEventArgs>*/, IWebhooksUpdatedEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, WebhooksUpdateEventArgs args) => OnWebhooksUpdated(client, args);
    public abstract Task OnWebhooksUpdated(DiscordClient client, WebhooksUpdateEventArgs args);
}

public interface IClientErroredEventHandler : IDiscordEventHandler/*, IDiscordEventHandler<ClientErrorEventArgs>*/
{
    public Task OnClientErrored(DiscordClient client, ClientErrorEventArgs args);
}
public abstract class ClientErroredEventHandler :DiscordEventHandler<ClientErrorEventArgs>/*, IDiscordEventHandler<ClientErrorEventArgs>*/, IClientErroredEventHandler
{
    public override sealed Task OnEvent(DiscordClient client, ClientErrorEventArgs args) => OnClientErrored(client, args);
    public abstract Task OnClientErrored(DiscordClient client, ClientErrorEventArgs args);
}

