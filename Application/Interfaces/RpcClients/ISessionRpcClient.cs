using Application.Commands.User.Session.ApplySessionAction;
using Application.Commands.User.Session.EndSession;
using Application.Commands.User.Session.JoinSession;
using Application.Commands.User.Session.LeaveSession;
using Application.Commands.User.Session.OpenSession;
using Application.Commands.User.Session.SetSessionReady;
using Application.Commands.User.Session.StartSession;
using Application.Queries.User.Session.GetCampaignSession;
using Application.Queries.User.Session.GetSession;
using Application.Queries.User.Session.ListMySessions;

namespace Application.Interfaces.RpcClients;

// The session service (game sessions of a campaign: lobby and play).
public interface ISessionRpcClient
{
    Task<RpcResult<SessionData>> OpenSession(OpenSessionCommand request, string token);
    Task<RpcResult<CampaignSessionData>> GetCampaignSession(GetCampaignSessionQuery request, string token);
    Task<RpcResult<SessionData>> GetSession(GetSessionQuery request, string token);
    Task<RpcResult<List<SessionNoticeData>>> ListMySessions(ListMySessionsQuery request, string token);
    Task<RpcResult<SessionData>> JoinSession(JoinSessionCommand request, string token);
    Task<RpcResult<SessionData>> LeaveSession(LeaveSessionCommand request, string token);
    Task<RpcResult<SessionData>> SetSessionReady(SetSessionReadyCommand request, string token);
    Task<RpcResult<SessionData>> StartSession(StartSessionCommand request, string token);
    Task<RpcResult<SessionData>> ApplySessionAction(ApplySessionActionCommand request, string token);
    Task<RpcResult<bool>> EndSession(EndSessionCommand request, string token);
}

// Status: "lobby" | "live". Enum values (conditions, resources, dice) come as camelCase names.
public record SessionData(
    Guid Id,
    Guid CampaignId,
    string CampaignTitle,
    Guid GmUserId,
    string GmName,
    string Status,
    DateTime OpenedAt,
    DateTime? StartedAt,
    List<SessionPlayerData> Players,
    List<SessionLogData> Log);

public record SessionPlayerData(Guid UserId, string Username, bool Ready, SessionCharacterData? Character);

public record SessionLogData(DateTime At, Guid UserId, Guid? CharacterId, string Text);

public record SessionCharacterData(
    Guid Id,
    string Name,
    string AvatarUrl,
    int Level,
    string Classes,
    int MaxHitPoints,
    int CurrentHitPoints,
    int TemporaryHitPoints,
    int ArmorClass,
    string ArmorClassSource,
    int Speed,
    int DeathSaveSuccesses,
    int DeathSaveFailures,
    bool IsDead,
    List<string> Conditions,
    int Exhaustion,
    SessionSpellRef? Concentration,
    int? ConcentrationCheckDc,
    List<string> Effects,
    List<SessionSlotData> SpellSlots,
    List<SessionResourceData> Resources,
    List<SessionHitDiceData> HitDice,
    List<SessionSpellData> Spells);

public record SessionSpellRef(Guid Id, string Name);

public record SessionSlotData(int Level, int Total, int Used, bool Pact);

public record SessionResourceData(string Type, string Name, int Current, int Max);

public record SessionHitDiceData(string Die, int Total, int Used);

public record SessionSpellData(Guid Id, string Name, int Level, bool Ritual, bool Concentration, int? FreeUsesLeft, bool RitualOnly);

// Session is null when the campaign has none open.
public record CampaignSessionData(SessionData? Session);

public record SessionNoticeData(Guid SessionId, Guid CampaignId, string CampaignTitle, string GmName, string Status);
