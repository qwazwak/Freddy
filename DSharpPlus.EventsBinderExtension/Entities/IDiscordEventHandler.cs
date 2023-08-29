using System.Threading.Tasks;
using DSharpPlus.EventArgs;

namespace DSharpPlus.EventsBinderExtension.Entities;

public interface IDiscordEventHandler
{
    //Task OnEvent(DiscordClient client, DiscordEventArgs args);
}

public interface IDiscordEventHandler<TArgs> : IDiscordEventHandler where TArgs : DiscordEventArgs
{
//    Task OnEvent(DiscordClient client, TArgs args);
}

public interface ISocketOpenedEventHandler : IDiscordEventHandler, IDiscordEventHandler<SocketEventArgs>
{
    public Task OnSocketOpened(DiscordClient client, SocketEventArgs args);
}

public interface ISocketClosedEventHandler : IDiscordEventHandler, IDiscordEventHandler<SocketCloseEventArgs>
{
    public Task OnSocketClosed(DiscordClient client, SocketCloseEventArgs args);
}

public interface IResumedEventHandler : IDiscordEventHandler, IDiscordEventHandler<ReadyEventArgs>
{
    public Task OnResumed(DiscordClient client, ReadyEventArgs args);
}

public interface IHeartbeatEventHandler : IDiscordEventHandler, IDiscordEventHandler<HeartbeatEventArgs>
{
    public Task OnHeartbeat(DiscordClient client, HeartbeatEventArgs args);
}

public interface IChannelCreatedEventHandler : IDiscordEventHandler, IDiscordEventHandler<ChannelCreateEventArgs>
{
    public Task OnChannelCreated(DiscordClient client, ChannelCreateEventArgs args);
}

public interface IReadyEventHandler : IDiscordEventHandler, IDiscordEventHandler<ReadyEventArgs>
{
    public Task OnReady(DiscordClient client, ReadyEventArgs args);
}

public interface IZombiedEventHandler : IDiscordEventHandler, IDiscordEventHandler<ZombiedEventArgs>
{
    public Task OnZombied(DiscordClient client, ZombiedEventArgs args);
}

public interface IChannelUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ChannelUpdateEventArgs>
{
    public Task OnChannelUpdate(DiscordClient client, ChannelUpdateEventArgs args);
}

public interface IChannelDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<ChannelDeleteEventArgs>
{
    public Task OnChannelDelete(DiscordClient client, ChannelDeleteEventArgs args);
}

public interface IDmChannelDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<DmChannelDeleteEventArgs>
{
    public Task OnDmChannelDelete(DiscordClient client, DmChannelDeleteEventArgs args);
}

public interface IChannelPinsUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ChannelPinsUpdateEventArgs>
{
    public Task OnChannelPinsUpdate(DiscordClient client, ChannelPinsUpdateEventArgs args);
}

public interface IGuildCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildCreateEventArgs>
{
    public Task OnGuildCreate(DiscordClient client, GuildCreateEventArgs args);
}

public interface IGuildUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildUpdateEventArgs>
{
    public Task OnGuildUpdate(DiscordClient client, GuildUpdateEventArgs args);
}

public interface IGuildDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildDeleteEventArgs>
{
    public Task OnGuildDelete(DiscordClient client, GuildDeleteEventArgs args);
}

public interface IGuildDownloadCompletedEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildDownloadCompletedEventArgs>
{
    public Task OnGuildDownloadCompleted(DiscordClient client, GuildDownloadCompletedEventArgs args);
}

public interface IGuildEmojisUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildEmojisUpdateEventArgs>
{
    public Task OnGuildEmojisUpdate(DiscordClient client, GuildEmojisUpdateEventArgs args);
}

public interface IGuildStickersUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildStickersUpdateEventArgs>
{
    public Task OnGuildStickersUpdate(DiscordClient client, GuildStickersUpdateEventArgs args);
}

public interface IGuildIntegrationsUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildIntegrationsUpdateEventArgs>
{
    public Task OnGuildIntegrationsUpdate(DiscordClient client, GuildIntegrationsUpdateEventArgs args);
}

public interface IScheduledGuildEventCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventCreateEventArgs>
{
    public Task OnScheduledGuildEventCreate(DiscordClient client, ScheduledGuildEventCreateEventArgs args);
}

public interface IScheduledGuildEventUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventUpdateEventArgs>
{
    public Task OnScheduledGuildEventUpdate(DiscordClient client, ScheduledGuildEventUpdateEventArgs args);
}

public interface IScheduledGuildEventDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventDeleteEventArgs>
{
    public Task OnScheduledGuildEventDelete(DiscordClient client, ScheduledGuildEventDeleteEventArgs args);
}

public interface IScheduledGuildEventCompletedEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventCompletedEventArgs>
{
    public Task OnScheduledGuildEventCompleted(DiscordClient client, ScheduledGuildEventCompletedEventArgs args);
}

public interface IScheduledGuildEventUserAddEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventUserAddEventArgs>
{
    public Task OnScheduledGuildEventUserAdd(DiscordClient client, ScheduledGuildEventUserAddEventArgs args);
}

public interface IScheduledGuildEventUserRemoveEventHandler : IDiscordEventHandler, IDiscordEventHandler<ScheduledGuildEventUserRemoveEventArgs>
{
    public Task OnScheduledGuildEventUserRemove(DiscordClient client, ScheduledGuildEventUserRemoveEventArgs args);
}

public interface IGuildBanAddEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildBanAddEventArgs>
{
    public Task OnGuildBanAdd(DiscordClient client, GuildBanAddEventArgs args);
}

public interface IGuildBanRemoveEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildBanRemoveEventArgs>
{
    public Task OnGuildBanRemove(DiscordClient client, GuildBanRemoveEventArgs args);
}

public interface IGuildMemberAddEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildMemberAddEventArgs>
{
    public Task OnGuildMemberAdd(DiscordClient client, GuildMemberAddEventArgs args);
}

public interface IGuildMemberRemoveEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildMemberRemoveEventArgs>
{
    public Task OnGuildMemberRemove(DiscordClient client, GuildMemberRemoveEventArgs args);
}

public interface IGuildMemberUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildMemberUpdateEventArgs>
{
    public Task OnGuildMemberUpdate(DiscordClient client, GuildMemberUpdateEventArgs args);
}

public interface IGuildMembersChunkEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildMembersChunkEventArgs>
{
    public Task OnGuildMembersChunk(DiscordClient client, GuildMembersChunkEventArgs args);
}

public interface IGuildRoleCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildRoleCreateEventArgs>
{
    public Task OnGuildRoleCreate(DiscordClient client, GuildRoleCreateEventArgs args);
}

public interface IGuildRoleUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildRoleUpdateEventArgs>
{
    public Task OnGuildRoleUpdate(DiscordClient client, GuildRoleUpdateEventArgs args);
}

public interface IGuildRoleDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<GuildRoleDeleteEventArgs>
{
    public Task OnGuildRoleDelete(DiscordClient client, GuildRoleDeleteEventArgs args);
}

public interface IInviteCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<InviteCreateEventArgs>
{
    public Task OnInviteCreate(DiscordClient client, InviteCreateEventArgs args);
}

public interface IInviteDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<InviteDeleteEventArgs>
{
    public Task OnInviteDelete(DiscordClient client, InviteDeleteEventArgs args);
}

public interface IMessageCreatedEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageCreateEventArgs>
{
    public Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args);
}

public interface IMessageAcknowledgeEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageAcknowledgeEventArgs>
{
    public Task OnMessageAcknowledge(DiscordClient client, MessageAcknowledgeEventArgs args);
}

public interface IMessageUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageUpdateEventArgs>
{
    public Task OnMessageUpdate(DiscordClient client, MessageUpdateEventArgs args);
}

public interface IMessageDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageDeleteEventArgs>
{
    public Task OnMessageDelete(DiscordClient client, MessageDeleteEventArgs args);
}

public interface IMessageBulkDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageBulkDeleteEventArgs>
{
    public Task OnMessageBulkDelete(DiscordClient client, MessageBulkDeleteEventArgs args);
}

public interface IMessageReactionAddEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageReactionAddEventArgs>
{
    public Task OnMessageReactionAdd(DiscordClient client, MessageReactionAddEventArgs args);
}

public interface IMessageReactionRemoveEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageReactionRemoveEventArgs>
{
    public Task OnMessageReactionRemove(DiscordClient client, MessageReactionRemoveEventArgs args);
}

public interface IMessageReactionsClearEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageReactionsClearEventArgs>
{
    public Task OnMessageReactionsClear(DiscordClient client, MessageReactionsClearEventArgs args);
}

public interface IMessageReactionRemoveEmojiEventHandler : IDiscordEventHandler, IDiscordEventHandler<MessageReactionRemoveEmojiEventArgs>
{
    public Task OnMessageReactionRemoveEmoji(DiscordClient client, MessageReactionRemoveEmojiEventArgs args);
}

public interface IPresenceUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<PresenceUpdateEventArgs>
{
    public Task OnPresenceUpdate(DiscordClient client, PresenceUpdateEventArgs args);
}

public interface IUserSettingsUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<UserSettingsUpdateEventArgs>
{
    public Task OnUserSettingsUpdate(DiscordClient client, UserSettingsUpdateEventArgs args);
}

public interface IUserUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<UserUpdateEventArgs>
{
    public Task OnUserUpdate(DiscordClient client, UserUpdateEventArgs args);
}

public interface IVoiceStateUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<VoiceStateUpdateEventArgs>
{
    public Task OnVoiceStateUpdate(DiscordClient client, VoiceStateUpdateEventArgs args);
}

public interface IVoiceServerUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<VoiceServerUpdateEventArgs>
{
    public Task OnVoiceServerUpdate(DiscordClient client, VoiceServerUpdateEventArgs args);
}

public interface IThreadCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadCreateEventArgs>
{
    public Task OnThreadCreate(DiscordClient client, ThreadCreateEventArgs args);
}

public interface IThreadUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadUpdateEventArgs>
{
    public Task OnThreadUpdate(DiscordClient client, ThreadUpdateEventArgs args);
}

public interface IThreadDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadDeleteEventArgs>
{
    public Task OnThreadDelete(DiscordClient client, ThreadDeleteEventArgs args);
}

public interface IThreadListSyncEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadListSyncEventArgs>
{
    public Task OnThreadListSync(DiscordClient client, ThreadListSyncEventArgs args);
}

public interface IThreadMemberUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadMemberUpdateEventArgs>
{
    public Task OnThreadMemberUpdate(DiscordClient client, ThreadMemberUpdateEventArgs args);
}

public interface IThreadMembersUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ThreadMembersUpdateEventArgs>
{
    public Task OnThreadMembersUpdate(DiscordClient client, ThreadMembersUpdateEventArgs args);
}

public interface IIntegrationCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<IntegrationCreateEventArgs>
{
    public Task OnIntegrationCreate(DiscordClient client, IntegrationCreateEventArgs args);
}

public interface IIntegrationUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<IntegrationUpdateEventArgs>
{
    public Task OnIntegrationUpdate(DiscordClient client, IntegrationUpdateEventArgs args);
}

public interface IIntegrationDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<IntegrationDeleteEventArgs>
{
    public Task OnIntegrationDelete(DiscordClient client, IntegrationDeleteEventArgs args);
}

public interface IStageInstanceCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<StageInstanceCreateEventArgs>
{
    public Task OnStageInstanceCreate(DiscordClient client, StageInstanceCreateEventArgs args);
}

public interface IStageInstanceUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<StageInstanceUpdateEventArgs>
{
    public Task OnStageInstanceUpdate(DiscordClient client, StageInstanceUpdateEventArgs args);
}

public interface IStageInstanceDeleteEventHandler : IDiscordEventHandler, IDiscordEventHandler<StageInstanceDeleteEventArgs>
{
    public Task OnStageInstanceDelete(DiscordClient client, StageInstanceDeleteEventArgs args);
}

public interface IInteractionCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<InteractionCreateEventArgs>
{
    public Task OnInteractionCreate(DiscordClient client, InteractionCreateEventArgs args);
}

public interface IComponentInteractionCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ComponentInteractionCreateEventArgs>
{
    public Task OnComponentInteractionCreate(DiscordClient client, ComponentInteractionCreateEventArgs args);
}

public interface IModalSubmitEventHandler : IDiscordEventHandler, IDiscordEventHandler<ModalSubmitEventArgs>
{
    public Task OnModalSubmit(DiscordClient client, ModalSubmitEventArgs args);
}

public interface IContextMenuInteractionCreateEventHandler : IDiscordEventHandler, IDiscordEventHandler<ContextMenuInteractionCreateEventArgs>
{
    public Task OnContextMenuInteractionCreate(DiscordClient client, ContextMenuInteractionCreateEventArgs args);
}

public interface ITypingStartEventHandler : IDiscordEventHandler, IDiscordEventHandler<TypingStartEventArgs>
{
    public Task OnTypingStart(DiscordClient client, TypingStartEventArgs args);
}

public interface IWebhooksUpdateEventHandler : IDiscordEventHandler, IDiscordEventHandler<WebhooksUpdateEventArgs>
{
    public Task OnWebhooksUpdate(DiscordClient client, WebhooksUpdateEventArgs args);
}

public interface IClientErrorEventHandler : IDiscordEventHandler, IDiscordEventHandler<ClientErrorEventArgs>
{
    public Task OnClientError(DiscordClient client, ClientErrorEventArgs args);
}
