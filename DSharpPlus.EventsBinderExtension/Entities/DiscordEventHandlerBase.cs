using System.Diagnostics;
using System.Threading.Tasks;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.EventsBinderExtension.Entities;

public abstract class DiscordEventHandlerBase : IDiscordEventHandler
{
    private protected readonly ILogger<DiscordEventHandlerBase>? logger;
    protected DiscordEventHandlerBase(ILogger<DiscordEventHandlerBase> logger) => this.logger = logger;
    protected DiscordEventHandlerBase() { }
    //public abstract Task OnEvent(DiscordClient client, DiscordEventArgs args);
}

public abstract class DiscordEventHandlerBase<TArgs> : DiscordEventHandlerBase, IDiscordEventHandler<TArgs> where TArgs : DiscordEventArgs
{
    protected DiscordEventHandlerBase(ILogger<DiscordEventHandlerBase> logger) : base(logger) { }
    protected DiscordEventHandlerBase() : base() { }
    /*
    public override sealed Task OnEvent(DiscordClient client, DiscordEventArgs args)
    {
        Debug.Assert(args is TArgs);
        return args is not TArgs ? Task.CompletedTask : OnEvent(client, (args as TArgs)!);
    }

    public abstract Task OnEvent(DiscordClient client, TArgs args);*/
}

public abstract class SocketOpenedEventHandlerBase : DiscordEventHandlerBase<SocketEventArgs>, ISocketOpenedEventHandler
{
    public SocketOpenedEventHandlerBase(ILogger<SocketOpenedEventHandlerBase> logger) : base(logger) { }
    public SocketOpenedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, SocketEventArgs args) => OnSocketOpened(client, args);
    public abstract Task OnSocketOpened(DiscordClient client, SocketEventArgs args);
}
public abstract class SocketClosedEventHandlerBase : DiscordEventHandlerBase<SocketCloseEventArgs>, ISocketClosedEventHandler
{
    public SocketClosedEventHandlerBase(ILogger<SocketClosedEventHandlerBase> logger) : base(logger) { }
    public SocketClosedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, SocketCloseEventArgs args) => OnSocketClosed(client, args);
    public abstract Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs args);
}
public abstract class ResumedEventHandlerBase : DiscordEventHandlerBase<ReadyEventArgs>, IResumedEventHandler
{
    public ResumedEventHandlerBase(ILogger<ResumedEventHandlerBase> logger) : base(logger) { }
    public ResumedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ReadyEventArgs args) => OnResumed(client, args);
    public abstract Task OnResumed(DiscordClient client, ReadyEventArgs args);
}
public abstract class HeartbeatEventHandlerBase : DiscordEventHandlerBase<HeartbeatEventArgs>, IHeartbeatEventHandler
{
    public HeartbeatEventHandlerBase(ILogger<HeartbeatEventHandlerBase> logger) : base(logger) { }
    public HeartbeatEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, HeartbeatEventArgs args) => OnHeartbeat(client, args);
    public abstract Task OnHeartbeat(DiscordClient client, HeartbeatEventArgs args);
}
public abstract class ChannelCreatedEventHandlerBase : DiscordEventHandlerBase<ChannelCreateEventArgs>, IChannelCreatedEventHandler
{
    public ChannelCreatedEventHandlerBase(ILogger<ChannelCreatedEventHandlerBase> logger) : base(logger) { }
    public ChannelCreatedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ChannelCreateEventArgs args) => OnChannelCreated(client, args);
    public abstract Task OnChannelCreated(DiscordClient client, ChannelCreateEventArgs args);
}
public abstract class ReadyEventHandlerBase : DiscordEventHandlerBase<ReadyEventArgs>, IReadyEventHandler
{
    public ReadyEventHandlerBase(ILogger<ReadyEventHandlerBase> logger) : base(logger) { }
    public ReadyEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ReadyEventArgs args) => OnReady(client, args);
    public abstract Task OnReady(DiscordClient client, ReadyEventArgs args);
}
public abstract class ZombiedEventHandlerBase : DiscordEventHandlerBase<ZombiedEventArgs>, IZombiedEventHandler
{
    public ZombiedEventHandlerBase(ILogger<ZombiedEventHandlerBase> logger) : base(logger) { }
    public ZombiedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ZombiedEventArgs args) => OnZombied(client, args);
    public abstract Task OnZombied(DiscordClient client, ZombiedEventArgs args);
}
public abstract class ChannelUpdateEventHandlerBase : DiscordEventHandlerBase<ChannelUpdateEventArgs>, IChannelUpdateEventHandler
{
    public ChannelUpdateEventHandlerBase(ILogger<ChannelUpdateEventHandlerBase> logger) : base(logger) { }
    public ChannelUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ChannelUpdateEventArgs args) => OnChannelUpdate(client, args);
    public abstract Task OnChannelUpdate(DiscordClient client, ChannelUpdateEventArgs args);
}
public abstract class ChannelDeleteEventHandlerBase : DiscordEventHandlerBase<ChannelDeleteEventArgs>, IChannelDeleteEventHandler
{
    public ChannelDeleteEventHandlerBase(ILogger<ChannelDeleteEventHandlerBase> logger) : base(logger) { }
    public ChannelDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ChannelDeleteEventArgs args) => OnChannelDelete(client, args);
    public abstract Task OnChannelDelete(DiscordClient client, ChannelDeleteEventArgs args);
}
public abstract class DmChannelDeleteEventHandlerBase : DiscordEventHandlerBase<DmChannelDeleteEventArgs>, IDmChannelDeleteEventHandler
{
    public DmChannelDeleteEventHandlerBase(ILogger<DmChannelDeleteEventHandlerBase> logger) : base(logger) { }
    public DmChannelDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, DmChannelDeleteEventArgs args) => OnDmChannelDelete(client, args);
    public abstract Task OnDmChannelDelete(DiscordClient client, DmChannelDeleteEventArgs args);
}
public abstract class ChannelPinsUpdateEventHandlerBase : DiscordEventHandlerBase<ChannelPinsUpdateEventArgs>, IChannelPinsUpdateEventHandler
{
    public ChannelPinsUpdateEventHandlerBase(ILogger<ChannelPinsUpdateEventHandlerBase> logger) : base(logger) { }
    public ChannelPinsUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ChannelPinsUpdateEventArgs args) => OnChannelPinsUpdate(client, args);
    public abstract Task OnChannelPinsUpdate(DiscordClient client, ChannelPinsUpdateEventArgs args);
}
public abstract class GuildCreateEventHandlerBase : DiscordEventHandlerBase<GuildCreateEventArgs>, IGuildCreateEventHandler
{
    public GuildCreateEventHandlerBase(ILogger<GuildCreateEventHandlerBase> logger) : base(logger) { }
    public GuildCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildCreateEventArgs args) => OnGuildCreate(client, args);
    public abstract Task OnGuildCreate(DiscordClient client, GuildCreateEventArgs args);
}
public abstract class GuildUpdateEventHandlerBase : DiscordEventHandlerBase<GuildUpdateEventArgs>, IGuildUpdateEventHandler
{
    public GuildUpdateEventHandlerBase(ILogger<GuildUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildUpdateEventArgs args) => OnGuildUpdate(client, args);
    public abstract Task OnGuildUpdate(DiscordClient client, GuildUpdateEventArgs args);
}
public abstract class GuildDeleteEventHandlerBase : DiscordEventHandlerBase<GuildDeleteEventArgs>, IGuildDeleteEventHandler
{
    public GuildDeleteEventHandlerBase(ILogger<GuildDeleteEventHandlerBase> logger) : base(logger) { }
    public GuildDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildDeleteEventArgs args) => OnGuildDelete(client, args);
    public abstract Task OnGuildDelete(DiscordClient client, GuildDeleteEventArgs args);
}
public abstract class GuildDownloadCompletedEventHandlerBase : DiscordEventHandlerBase<GuildDownloadCompletedEventArgs>, IGuildDownloadCompletedEventHandler
{
    public GuildDownloadCompletedEventHandlerBase(ILogger<GuildDownloadCompletedEventHandlerBase> logger) : base(logger) { }
    public GuildDownloadCompletedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildDownloadCompletedEventArgs args) => OnGuildDownloadCompleted(client, args);
    public abstract Task OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args);
}
public abstract class GuildEmojisUpdateEventHandlerBase : DiscordEventHandlerBase<GuildEmojisUpdateEventArgs>, IGuildEmojisUpdateEventHandler
{
    public GuildEmojisUpdateEventHandlerBase(ILogger<GuildEmojisUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildEmojisUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildEmojisUpdateEventArgs args) => OnGuildEmojisUpdate(client, args);
    public abstract Task OnGuildEmojisUpdate(DiscordClient client, GuildEmojisUpdateEventArgs args);
}
public abstract class GuildStickersUpdateEventHandlerBase : DiscordEventHandlerBase<GuildStickersUpdateEventArgs>, IGuildStickersUpdateEventHandler
{
    public GuildStickersUpdateEventHandlerBase(ILogger<GuildStickersUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildStickersUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildStickersUpdateEventArgs args) => OnGuildStickersUpdate(client, args);
    public abstract Task OnGuildStickersUpdate(DiscordClient client, GuildStickersUpdateEventArgs args);
}
public abstract class GuildIntegrationsUpdateEventHandlerBase : DiscordEventHandlerBase<GuildIntegrationsUpdateEventArgs>, IGuildIntegrationsUpdateEventHandler
{
    public GuildIntegrationsUpdateEventHandlerBase(ILogger<GuildIntegrationsUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildIntegrationsUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildIntegrationsUpdateEventArgs args) => OnGuildIntegrationsUpdate(client, args);
    public abstract Task OnGuildIntegrationsUpdate(DiscordClient client, GuildIntegrationsUpdateEventArgs args);
}
public abstract class ScheduledGuildEventCreateEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventCreateEventArgs>, IScheduledGuildEventCreateEventHandler
{
    public ScheduledGuildEventCreateEventHandlerBase(ILogger<ScheduledGuildEventCreateEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventCreateEventArgs args) => OnScheduledGuildEventCreate(client, args);
    public abstract Task OnScheduledGuildEventCreate(DiscordClient client, ScheduledGuildEventCreateEventArgs args);
}
public abstract class ScheduledGuildEventUpdateEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventUpdateEventArgs>, IScheduledGuildEventUpdateEventHandler
{
    public ScheduledGuildEventUpdateEventHandlerBase(ILogger<ScheduledGuildEventUpdateEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUpdateEventArgs args) => OnScheduledGuildEventUpdate(client, args);
    public abstract Task OnScheduledGuildEventUpdate(DiscordClient client, ScheduledGuildEventUpdateEventArgs args);
}
public abstract class ScheduledGuildEventDeleteEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventDeleteEventArgs>, IScheduledGuildEventDeleteEventHandler
{
    public ScheduledGuildEventDeleteEventHandlerBase(ILogger<ScheduledGuildEventDeleteEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventDeleteEventArgs args) => OnScheduledGuildEventDelete(client, args);
    public abstract Task OnScheduledGuildEventDelete(DiscordClient client, ScheduledGuildEventDeleteEventArgs args);
}
public abstract class ScheduledGuildEventCompletedEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventCompletedEventArgs>, IScheduledGuildEventCompletedEventHandler
{
    public ScheduledGuildEventCompletedEventHandlerBase(ILogger<ScheduledGuildEventCompletedEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventCompletedEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventCompletedEventArgs args) => OnScheduledGuildEventCompleted(client, args);
    public abstract Task OnScheduledGuildEventCompleted(DiscordClient client, ScheduledGuildEventCompletedEventArgs args);
}
public abstract class ScheduledGuildEventUserAddEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventUserAddEventArgs>, IScheduledGuildEventUserAddEventHandler
{
    public ScheduledGuildEventUserAddEventHandlerBase(ILogger<ScheduledGuildEventUserAddEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventUserAddEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUserAddEventArgs args) => OnScheduledGuildEventUserAdd(client, args);
    public abstract Task OnScheduledGuildEventUserAdd(DiscordClient client, ScheduledGuildEventUserAddEventArgs args);
}
public abstract class ScheduledGuildEventUserRemoveEventHandlerBase : DiscordEventHandlerBase<ScheduledGuildEventUserRemoveEventArgs>, IScheduledGuildEventUserRemoveEventHandler
{
    public ScheduledGuildEventUserRemoveEventHandlerBase(ILogger<ScheduledGuildEventUserRemoveEventHandlerBase> logger) : base(logger) { }
    public ScheduledGuildEventUserRemoveEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args) => OnScheduledGuildEventUserRemove(client, args);
    public abstract Task OnScheduledGuildEventUserRemove(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args);
}
public abstract class GuildBanAddEventHandlerBase : DiscordEventHandlerBase<GuildBanAddEventArgs>, IGuildBanAddEventHandler
{
    public GuildBanAddEventHandlerBase(ILogger<GuildBanAddEventHandlerBase> logger) : base(logger) { }
    public GuildBanAddEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildBanAddEventArgs args) => OnGuildBanAdd(client, args);
    public abstract Task OnGuildBanAdd(DiscordClient client, GuildBanAddEventArgs args);
}
public abstract class GuildBanRemoveEventHandlerBase : DiscordEventHandlerBase<GuildBanRemoveEventArgs>, IGuildBanRemoveEventHandler
{
    public GuildBanRemoveEventHandlerBase(ILogger<GuildBanRemoveEventHandlerBase> logger) : base(logger) { }
    public GuildBanRemoveEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildBanRemoveEventArgs args) => OnGuildBanRemove(client, args);
    public abstract Task OnGuildBanRemove(DiscordClient client, GuildBanRemoveEventArgs args);
}
public abstract class GuildMemberAddEventHandlerBase : DiscordEventHandlerBase<GuildMemberAddEventArgs>, IGuildMemberAddEventHandler
{
    public GuildMemberAddEventHandlerBase(ILogger<GuildMemberAddEventHandlerBase> logger) : base(logger) { }
    public GuildMemberAddEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildMemberAddEventArgs args) => OnGuildMemberAdd(client, args);
    public abstract Task OnGuildMemberAdd(DiscordClient client, GuildMemberAddEventArgs args);
}
public abstract class GuildMemberRemoveEventHandlerBase : DiscordEventHandlerBase<GuildMemberRemoveEventArgs>, IGuildMemberRemoveEventHandler
{
    public GuildMemberRemoveEventHandlerBase(ILogger<GuildMemberRemoveEventHandlerBase> logger) : base(logger) { }
    public GuildMemberRemoveEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildMemberRemoveEventArgs args) => OnGuildMemberRemove(client, args);
    public abstract Task OnGuildMemberRemove(DiscordClient client, GuildMemberRemoveEventArgs args);
}
public abstract class GuildMemberUpdateEventHandlerBase : DiscordEventHandlerBase<GuildMemberUpdateEventArgs>, IGuildMemberUpdateEventHandler
{
    public GuildMemberUpdateEventHandlerBase(ILogger<GuildMemberUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildMemberUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildMemberUpdateEventArgs args) => OnGuildMemberUpdate(client, args);
    public abstract Task OnGuildMemberUpdate(DiscordClient client, GuildMemberUpdateEventArgs args);
}
public abstract class GuildMembersChunkEventHandlerBase : DiscordEventHandlerBase<GuildMembersChunkEventArgs>, IGuildMembersChunkEventHandler
{
    public GuildMembersChunkEventHandlerBase(ILogger<GuildMembersChunkEventHandlerBase> logger) : base(logger) { }
    public GuildMembersChunkEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildMembersChunkEventArgs args) => OnGuildMembersChunk(client, args);
    public abstract Task OnGuildMembersChunk(DiscordClient client, GuildMembersChunkEventArgs args);
}
public abstract class GuildRoleCreateEventHandlerBase : DiscordEventHandlerBase<GuildRoleCreateEventArgs>, IGuildRoleCreateEventHandler
{
    public GuildRoleCreateEventHandlerBase(ILogger<GuildRoleCreateEventHandlerBase> logger) : base(logger) { }
    public GuildRoleCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildRoleCreateEventArgs args) => OnGuildRoleCreate(client, args);
    public abstract Task OnGuildRoleCreate(DiscordClient client, GuildRoleCreateEventArgs args);
}
public abstract class GuildRoleUpdateEventHandlerBase : DiscordEventHandlerBase<GuildRoleUpdateEventArgs>, IGuildRoleUpdateEventHandler
{
    public GuildRoleUpdateEventHandlerBase(ILogger<GuildRoleUpdateEventHandlerBase> logger) : base(logger) { }
    public GuildRoleUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildRoleUpdateEventArgs args) => OnGuildRoleUpdate(client, args);
    public abstract Task OnGuildRoleUpdate(DiscordClient client, GuildRoleUpdateEventArgs args);
}
public abstract class GuildRoleDeleteEventHandlerBase : DiscordEventHandlerBase<GuildRoleDeleteEventArgs>, IGuildRoleDeleteEventHandler
{
    public GuildRoleDeleteEventHandlerBase(ILogger<GuildRoleDeleteEventHandlerBase> logger) : base(logger) { }
    public GuildRoleDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, GuildRoleDeleteEventArgs args) => OnGuildRoleDelete(client, args);
    public abstract Task OnGuildRoleDelete(DiscordClient client, GuildRoleDeleteEventArgs args);
}
public abstract class InviteCreateEventHandlerBase : DiscordEventHandlerBase<InviteCreateEventArgs>, IInviteCreateEventHandler
{
    public InviteCreateEventHandlerBase(ILogger<InviteCreateEventHandlerBase> logger) : base(logger) { }
    public InviteCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, InviteCreateEventArgs args) => OnInviteCreate(client, args);
    public abstract Task OnInviteCreate(DiscordClient client, InviteCreateEventArgs args);
}
public abstract class InviteDeleteEventHandlerBase : DiscordEventHandlerBase<InviteDeleteEventArgs>, IInviteDeleteEventHandler
{
    public InviteDeleteEventHandlerBase(ILogger<InviteDeleteEventHandlerBase> logger) : base(logger) { }
    public InviteDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, InviteDeleteEventArgs args) => OnInviteDelete(client, args);
    public abstract Task OnInviteDelete(DiscordClient client, InviteDeleteEventArgs args);
}
public abstract class MessageCreatedEventHandler : DiscordEventHandlerBase<MessageCreateEventArgs>, IMessageCreatedEventHandler
{
    public MessageCreatedEventHandler(ILogger<MessageCreatedEventHandler> logger) : base(logger) { }
    public MessageCreatedEventHandler() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageCreateEventArgs args) => OnMessageCreate(client, args);
    public abstract Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args);
}
public abstract class MessageAcknowledgeEventHandlerBase : DiscordEventHandlerBase<MessageAcknowledgeEventArgs>, IMessageAcknowledgeEventHandler
{
    public MessageAcknowledgeEventHandlerBase(ILogger<MessageAcknowledgeEventHandlerBase> logger) : base(logger) { }
    public MessageAcknowledgeEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageAcknowledgeEventArgs args) => OnMessageAcknowledge(client, args);
    public abstract Task OnMessageAcknowledge(DiscordClient client, MessageAcknowledgeEventArgs args);
}
public abstract class MessageUpdateEventHandlerBase : DiscordEventHandlerBase<MessageUpdateEventArgs>, IMessageUpdateEventHandler
{
    public MessageUpdateEventHandlerBase(ILogger<MessageUpdateEventHandlerBase> logger) : base(logger) { }
    public MessageUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageUpdateEventArgs args) => OnMessageUpdate(client, args);
    public abstract Task OnMessageUpdate(DiscordClient client, MessageUpdateEventArgs args);
}
public abstract class MessageDeleteEventHandlerBase : DiscordEventHandlerBase<MessageDeleteEventArgs>, IMessageDeleteEventHandler
{
    public MessageDeleteEventHandlerBase(ILogger<MessageDeleteEventHandlerBase> logger) : base(logger) { }
    public MessageDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageDeleteEventArgs args) => OnMessageDelete(client, args);
    public abstract Task OnMessageDelete(DiscordClient client, MessageDeleteEventArgs args);
}
public abstract class MessageBulkDeleteEventHandlerBase : DiscordEventHandlerBase<MessageBulkDeleteEventArgs>, IMessageBulkDeleteEventHandler
{
    public MessageBulkDeleteEventHandlerBase(ILogger<MessageBulkDeleteEventHandlerBase> logger) : base(logger) { }
    public MessageBulkDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageBulkDeleteEventArgs args) => OnMessageBulkDelete(client, args);
    public abstract Task OnMessageBulkDelete(DiscordClient client, MessageBulkDeleteEventArgs args);
}
public abstract class MessageReactionAddEventHandlerBase : DiscordEventHandlerBase<MessageReactionAddEventArgs>, IMessageReactionAddEventHandler
{
    public MessageReactionAddEventHandlerBase(ILogger<MessageReactionAddEventHandlerBase> logger) : base(logger) { }
    public MessageReactionAddEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageReactionAddEventArgs args) => OnMessageReactionAdd(client, args);
    public abstract Task OnMessageReactionAdd(DiscordClient client, MessageReactionAddEventArgs args);
}
public abstract class MessageReactionRemoveEventHandlerBase : DiscordEventHandlerBase<MessageReactionRemoveEventArgs>, IMessageReactionRemoveEventHandler
{
    public MessageReactionRemoveEventHandlerBase(ILogger<MessageReactionRemoveEventHandlerBase> logger) : base(logger) { }
    public MessageReactionRemoveEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageReactionRemoveEventArgs args) => OnMessageReactionRemove(client, args);
    public abstract Task OnMessageReactionRemove(DiscordClient client, MessageReactionRemoveEventArgs args);
}
public abstract class MessageReactionsClearEventHandlerBase : DiscordEventHandlerBase<MessageReactionsClearEventArgs>, IMessageReactionsClearEventHandler
{
    public MessageReactionsClearEventHandlerBase(ILogger<MessageReactionsClearEventHandlerBase> logger) : base(logger) { }
    public MessageReactionsClearEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageReactionsClearEventArgs args) => OnMessageReactionsClear(client, args);
    public abstract Task OnMessageReactionsClear(DiscordClient client, MessageReactionsClearEventArgs args);
}
public abstract class MessageReactionRemoveEmojiEventHandlerBase : DiscordEventHandlerBase<MessageReactionRemoveEmojiEventArgs>, IMessageReactionRemoveEmojiEventHandler
{
    public MessageReactionRemoveEmojiEventHandlerBase(ILogger<MessageReactionRemoveEmojiEventHandlerBase> logger) : base(logger) { }
    public MessageReactionRemoveEmojiEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, MessageReactionRemoveEmojiEventArgs args) => OnMessageReactionRemoveEmoji(client, args);
    public abstract Task OnMessageReactionRemoveEmoji(DiscordClient client, MessageReactionRemoveEmojiEventArgs args);
}
public abstract class PresenceUpdateEventHandlerBase : DiscordEventHandlerBase<PresenceUpdateEventArgs>, IPresenceUpdateEventHandler
{
    public PresenceUpdateEventHandlerBase(ILogger<PresenceUpdateEventHandlerBase> logger) : base(logger) { }
    public PresenceUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, PresenceUpdateEventArgs args) => OnPresenceUpdate(client, args);
    public abstract Task OnPresenceUpdate(DiscordClient client, PresenceUpdateEventArgs args);
}
public abstract class UserSettingsUpdateEventHandlerBase : DiscordEventHandlerBase<UserSettingsUpdateEventArgs>, IUserSettingsUpdateEventHandler
{
    public UserSettingsUpdateEventHandlerBase(ILogger<UserSettingsUpdateEventHandlerBase> logger) : base(logger) { }
    public UserSettingsUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, UserSettingsUpdateEventArgs args) => OnUserSettingsUpdate(client, args);
    public abstract Task OnUserSettingsUpdate(DiscordClient client, UserSettingsUpdateEventArgs args);
}
public abstract class UserUpdateEventHandlerBase : DiscordEventHandlerBase<UserUpdateEventArgs>, IUserUpdateEventHandler
{
    public UserUpdateEventHandlerBase(ILogger<UserUpdateEventHandlerBase> logger) : base(logger) { }
    public UserUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, UserUpdateEventArgs args) => OnUserUpdate(client, args);
    public abstract Task OnUserUpdate(DiscordClient client, UserUpdateEventArgs args);
}
public abstract class VoiceStateUpdateEventHandlerBase : DiscordEventHandlerBase<VoiceStateUpdateEventArgs>, IVoiceStateUpdateEventHandler
{
    public VoiceStateUpdateEventHandlerBase(ILogger<VoiceStateUpdateEventHandlerBase> logger) : base(logger) { }
    public VoiceStateUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, VoiceStateUpdateEventArgs args) => OnVoiceStateUpdate(client, args);
    public abstract Task OnVoiceStateUpdate(DiscordClient client, VoiceStateUpdateEventArgs args);
}
public abstract class VoiceServerUpdateEventHandlerBase : DiscordEventHandlerBase<VoiceServerUpdateEventArgs>, IVoiceServerUpdateEventHandler
{
    public VoiceServerUpdateEventHandlerBase(ILogger<VoiceServerUpdateEventHandlerBase> logger) : base(logger) { }
    public VoiceServerUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, VoiceServerUpdateEventArgs args) => OnVoiceServerUpdate(client, args);
    public abstract Task OnVoiceServerUpdate(DiscordClient client, VoiceServerUpdateEventArgs args);
}
public abstract class ThreadCreateEventHandlerBase : DiscordEventHandlerBase<ThreadCreateEventArgs>, IThreadCreateEventHandler
{
    public ThreadCreateEventHandlerBase(ILogger<ThreadCreateEventHandlerBase> logger) : base(logger) { }
    public ThreadCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadCreateEventArgs args) => OnThreadCreate(client, args);
    public abstract Task OnThreadCreate(DiscordClient client, ThreadCreateEventArgs args);
}
public abstract class ThreadUpdateEventHandlerBase : DiscordEventHandlerBase<ThreadUpdateEventArgs>, IThreadUpdateEventHandler
{
    public ThreadUpdateEventHandlerBase(ILogger<ThreadUpdateEventHandlerBase> logger) : base(logger) { }
    public ThreadUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadUpdateEventArgs args) => OnThreadUpdate(client, args);
    public abstract Task OnThreadUpdate(DiscordClient client, ThreadUpdateEventArgs args);
}
public abstract class ThreadDeleteEventHandlerBase : DiscordEventHandlerBase<ThreadDeleteEventArgs>, IThreadDeleteEventHandler
{
    public ThreadDeleteEventHandlerBase(ILogger<ThreadDeleteEventHandlerBase> logger) : base(logger) { }
    public ThreadDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadDeleteEventArgs args) => OnThreadDelete(client, args);
    public abstract Task OnThreadDelete(DiscordClient client, ThreadDeleteEventArgs args);
}
public abstract class ThreadListSyncEventHandlerBase : DiscordEventHandlerBase<ThreadListSyncEventArgs>, IThreadListSyncEventHandler
{
    public ThreadListSyncEventHandlerBase(ILogger<ThreadListSyncEventHandlerBase> logger) : base(logger) { }
    public ThreadListSyncEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadListSyncEventArgs args) => OnThreadListSync(client, args);
    public abstract Task OnThreadListSync(DiscordClient client, ThreadListSyncEventArgs args);
}
public abstract class ThreadMemberUpdateEventHandlerBase : DiscordEventHandlerBase<ThreadMemberUpdateEventArgs>, IThreadMemberUpdateEventHandler
{
    public ThreadMemberUpdateEventHandlerBase(ILogger<ThreadMemberUpdateEventHandlerBase> logger) : base(logger) { }
    public ThreadMemberUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadMemberUpdateEventArgs args) => OnThreadMemberUpdate(client, args);
    public abstract Task OnThreadMemberUpdate(DiscordClient client, ThreadMemberUpdateEventArgs args);
}
public abstract class ThreadMembersUpdateEventHandlerBase : DiscordEventHandlerBase<ThreadMembersUpdateEventArgs>, IThreadMembersUpdateEventHandler
{
    public ThreadMembersUpdateEventHandlerBase(ILogger<ThreadMembersUpdateEventHandlerBase> logger) : base(logger) { }
    public ThreadMembersUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ThreadMembersUpdateEventArgs args) => OnThreadMembersUpdate(client, args);
    public abstract Task OnThreadMembersUpdate(DiscordClient client, ThreadMembersUpdateEventArgs args);
}
public abstract class IntegrationCreateEventHandlerBase : DiscordEventHandlerBase<IntegrationCreateEventArgs>, IIntegrationCreateEventHandler
{
    public IntegrationCreateEventHandlerBase(ILogger<IntegrationCreateEventHandlerBase> logger) : base(logger) { }
    public IntegrationCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, IntegrationCreateEventArgs args) => OnIntegrationCreate(client, args);
    public abstract Task OnIntegrationCreate(DiscordClient client, IntegrationCreateEventArgs args);
}
public abstract class IntegrationUpdateEventHandlerBase : DiscordEventHandlerBase<IntegrationUpdateEventArgs>, IIntegrationUpdateEventHandler
{
    public IntegrationUpdateEventHandlerBase(ILogger<IntegrationUpdateEventHandlerBase> logger) : base(logger) { }
    public IntegrationUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, IntegrationUpdateEventArgs args) => OnIntegrationUpdate(client, args);
    public abstract Task OnIntegrationUpdate(DiscordClient client, IntegrationUpdateEventArgs args);
}
public abstract class IntegrationDeleteEventHandlerBase : DiscordEventHandlerBase<IntegrationDeleteEventArgs>, IIntegrationDeleteEventHandler
{
    public IntegrationDeleteEventHandlerBase(ILogger<IntegrationDeleteEventHandlerBase> logger) : base(logger) { }
    public IntegrationDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, IntegrationDeleteEventArgs args) => OnIntegrationDelete(client, args);
    public abstract Task OnIntegrationDelete(DiscordClient client, IntegrationDeleteEventArgs args);
}
public abstract class StageInstanceCreateEventHandlerBase : DiscordEventHandlerBase<StageInstanceCreateEventArgs>, IStageInstanceCreateEventHandler
{
    public StageInstanceCreateEventHandlerBase(ILogger<StageInstanceCreateEventHandlerBase> logger) : base(logger) { }
    public StageInstanceCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, StageInstanceCreateEventArgs args) => OnStageInstanceCreate(client, args);
    public abstract Task OnStageInstanceCreate(DiscordClient client, StageInstanceCreateEventArgs args);
}
public abstract class StageInstanceUpdateEventHandlerBase : DiscordEventHandlerBase<StageInstanceUpdateEventArgs>, IStageInstanceUpdateEventHandler
{
    public StageInstanceUpdateEventHandlerBase(ILogger<StageInstanceUpdateEventHandlerBase> logger) : base(logger) { }
    public StageInstanceUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, StageInstanceUpdateEventArgs args) => OnStageInstanceUpdate(client, args);
    public abstract Task OnStageInstanceUpdate(DiscordClient client, StageInstanceUpdateEventArgs args);
}
public abstract class StageInstanceDeleteEventHandlerBase : DiscordEventHandlerBase<StageInstanceDeleteEventArgs>, IStageInstanceDeleteEventHandler
{
    public StageInstanceDeleteEventHandlerBase(ILogger<StageInstanceDeleteEventHandlerBase> logger) : base(logger) { }
    public StageInstanceDeleteEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, StageInstanceDeleteEventArgs args) => OnStageInstanceDelete(client, args);
    public abstract Task OnStageInstanceDelete(DiscordClient client, StageInstanceDeleteEventArgs args);
}
public abstract class InteractionCreateEventHandlerBase : DiscordEventHandlerBase<InteractionCreateEventArgs>, IInteractionCreateEventHandler
{
    public InteractionCreateEventHandlerBase(ILogger<InteractionCreateEventHandlerBase> logger) : base(logger) { }
    public InteractionCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, InteractionCreateEventArgs args) => OnInteractionCreate(client, args);
    public abstract Task OnInteractionCreate(DiscordClient client, InteractionCreateEventArgs args);
}
public abstract class ComponentInteractionCreateEventHandlerBase : DiscordEventHandlerBase<ComponentInteractionCreateEventArgs>, IComponentInteractionCreateEventHandler
{
    public ComponentInteractionCreateEventHandlerBase(ILogger<ComponentInteractionCreateEventHandlerBase> logger) : base(logger) { }
    public ComponentInteractionCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ComponentInteractionCreateEventArgs args) => OnComponentInteractionCreate(client, args);
    public abstract Task OnComponentInteractionCreate(DiscordClient client, ComponentInteractionCreateEventArgs args);
}
public abstract class ModalSubmitEventHandlerBase : DiscordEventHandlerBase<ModalSubmitEventArgs>, IModalSubmitEventHandler
{
    public ModalSubmitEventHandlerBase(ILogger<ModalSubmitEventHandlerBase> logger) : base(logger) { }
    public ModalSubmitEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ModalSubmitEventArgs args) => OnModalSubmit(client, args);
    public abstract Task OnModalSubmit(DiscordClient client, ModalSubmitEventArgs args);
}
public abstract class ContextMenuInteractionCreateEventHandlerBase : DiscordEventHandlerBase<ContextMenuInteractionCreateEventArgs>, IContextMenuInteractionCreateEventHandler
{
    public ContextMenuInteractionCreateEventHandlerBase(ILogger<ContextMenuInteractionCreateEventHandlerBase> logger) : base(logger) { }
    public ContextMenuInteractionCreateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ContextMenuInteractionCreateEventArgs args) => OnContextMenuInteractionCreate(client, args);
    public abstract Task OnContextMenuInteractionCreate(DiscordClient client, ContextMenuInteractionCreateEventArgs args);
}
public abstract class TypingStartEventHandlerBase : DiscordEventHandlerBase<TypingStartEventArgs>, ITypingStartEventHandler
{
    public TypingStartEventHandlerBase(ILogger<TypingStartEventHandlerBase> logger) : base(logger) { }
    public TypingStartEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, TypingStartEventArgs args) => OnTypingStart(client, args);
    public abstract Task OnTypingStart(DiscordClient client, TypingStartEventArgs args);
}
public abstract class WebhooksUpdateEventHandlerBase : DiscordEventHandlerBase<WebhooksUpdateEventArgs>, IWebhooksUpdateEventHandler
{
    public WebhooksUpdateEventHandlerBase(ILogger<WebhooksUpdateEventHandlerBase> logger) : base(logger) { }
    public WebhooksUpdateEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, WebhooksUpdateEventArgs args) => OnWebhooksUpdate(client, args);
    public abstract Task OnWebhooksUpdate(DiscordClient client, WebhooksUpdateEventArgs args);
}
public abstract class ClientErrorEventHandlerBase : DiscordEventHandlerBase<ClientErrorEventArgs>, IClientErrorEventHandler
{
    public ClientErrorEventHandlerBase(ILogger<ClientErrorEventHandlerBase> logger) : base(logger) { }
    public ClientErrorEventHandlerBase() : base() { }

    //public override sealed Task OnEvent(DiscordClient client, ClientErrorEventArgs args) => OnClientError(client, args);
    public abstract Task OnClientError(DiscordClient client, ClientErrorEventArgs args);
}