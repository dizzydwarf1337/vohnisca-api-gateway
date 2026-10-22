using Application.Queries.User.Session.GetEncounter;
using Application.Commands.User.Session.StartCombat;
using Application.Commands.User.Session.JoinCombat;
using Application.Commands.User.Session.RemoveCombatant;
using Application.Commands.User.Session.SetInitiative;
using Application.Commands.User.Session.EndTurn;
using Application.Commands.User.Session.EndCombat;
using Application.Commands.User.Session.SetSpent;
using Application.Commands.User.Session.Dash;
using Application.Commands.User.Session.Attack;
using Application.Queries.User.Session.GetDiceRolls;
using Application.Commands.User.Session.RollDice;
using Application.Commands.User.Session.RollCheck;
using Application.Queries.User.Session.GetScene;
using Application.Commands.User.Session.SetScene;
using Application.Commands.User.Session.SetSceneFog;
using Application.Commands.User.Session.RevealSceneCells;
using Application.Commands.User.Session.AddSceneToken;
using Application.Commands.User.Session.UpdateSceneToken;
using Application.Commands.User.Session.RemoveSceneToken;
using Application.Commands.User.Session.MoveSceneToken;
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

    Task<RpcResult<SessionSceneData>> GetScene(GetSceneQuery request, string token);
    Task<RpcResult<SessionSceneData>> SetScene(SetSceneCommand request, string token);
    Task<RpcResult<SessionSceneData>> SetSceneFog(SetSceneFogCommand request, string token);
    Task<RpcResult<SessionSceneData>> RevealSceneCells(RevealSceneCellsCommand request, string token);
    Task<RpcResult<SessionSceneData>> AddSceneToken(AddSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> UpdateSceneToken(UpdateSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> RemoveSceneToken(RemoveSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> MoveSceneToken(MoveSceneTokenCommand request, string token);

    Task<RpcResult<DiceRollsData>> GetDiceRolls(GetDiceRollsQuery request, string token);
    Task<RpcResult<DiceRollData>> RollDice(RollDiceCommand request, string token);
    Task<RpcResult<DiceRollData>> RollCheck(RollCheckCommand request, string token);

    Task<RpcResult<SessionEncounterData>> GetEncounter(GetEncounterQuery request, string token);
    Task<RpcResult<SessionEncounterData>> StartCombat(StartCombatCommand request, string token);
    Task<RpcResult<SessionEncounterData>> JoinCombat(JoinCombatCommand request, string token);
    Task<RpcResult<SessionEncounterData>> RemoveCombatant(RemoveCombatantCommand request, string token);
    Task<RpcResult<SessionEncounterData>> SetInitiative(SetInitiativeCommand request, string token);
    Task<RpcResult<SessionEncounterData>> EndTurn(EndTurnCommand request, string token);
    Task<RpcResult<bool>> EndCombat(EndCombatCommand request, string token);
    Task<RpcResult<SessionEncounterData>> SetSpent(SetSpentCommand request, string token);
    Task<RpcResult<SessionEncounterData>> Dash(DashCommand request, string token);
    Task<RpcResult<AttackResultData>> Attack(AttackCommand request, string token);
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
    List<SessionSpellData> Spells,
    List<AttackOptionData> Attacks,
    int? SpellAttackBonus);

// An attack the character can make (CombatRules.AttackOption): damage is DiceCount dice of
// DieFaces + DamageBonus (DamageMin: a die below it counts as it); Reach in feet for
// melee, RangeNormal / RangeLong for ranged; BonusAction: the two-weapon extra attack.
public record AttackOptionData(
    string Id,
    string Name,
    int AttackBonus,
    int DiceCount,
    int DieFaces,
    int DamageBonus,
    int? DamageMin,
    string DamageType,
    bool Ranged,
    int Reach,
    int? RangeNormal,
    int? RangeLong,
    bool BonusAction);

public record SessionSpellRef(Guid Id, string Name);

public record SessionSlotData(int Level, int Total, int Used, bool Pact);

public record SessionResourceData(string Type, string Name, int Current, int Max);

public record SessionHitDiceData(string Die, int Total, int Used);

public record SessionSpellData(Guid Id, string Name, int Level, bool Ritual, bool Concentration, int? FreeUsesLeft, bool RitualOnly);

// Session is null when the campaign has none open.
public record CampaignSessionData(SessionData? Session);

public record SessionNoticeData(Guid SessionId, Guid CampaignId, string CampaignTitle, string GmName, string Status);

// The map of a session as the user may see it (Scene is null until the GM sets one).
public record SessionSceneData(SceneData? Scene);

// Revealed: cells (row * cols + col) the players see when Fog is on.
public record SceneData(
    string Name,
    string ImageUrl,
    int Cols,
    int Rows,
    int StartCol,
    int StartRow,
    bool Fog,
    List<int> Revealed,
    List<SceneTokenData> Tokens);

// Kind: "character" | "npc" | "item" | "marker"; OwnerUserId: the player of a character token.
public record SceneTokenData(
    Guid Id,
    string Kind,
    Guid? RefId,
    string Name,
    string ImageUrl,
    int Col,
    int Row,
    int Size,
    int Quantity,
    bool Hidden,
    Guid? OwnerUserId,
    int? MaxHp,
    int? Hp,
    int? Ac,
    int? Speed,
    int? InitiativeBonus,
    string? Health);

// A roll at the table. Terms: each part of the roll (dice with their rolls and the dropped
// ones, or a flat number). Outcome: what a rule roll decided ("Success", "Heals 7").
public record DiceRollData(
    Guid Id,
    DateTime At,
    Guid UserId,
    string Username,
    Guid? CharacterId,
    string? CharacterName,
    string? Label,
    string Expression,
    int Total,
    List<DiceTermData> Terms,
    bool Secret,
    string? Outcome);

public record DiceTermData(string Text, int Sign, List<int> Rolls, List<int> Dropped, int Value);

public record DiceRollsData(List<DiceRollData> Rolls);

// The fight (Encounter is null when there's none).
public record SessionEncounterData(EncounterData? Encounter);

public record EncounterData(int Round, Guid? CurrentTokenId, List<CombatantData> Order);

// Health: how hurt an NPC looks. What's spent this turn: action, bonus action, reaction,
// movement (MovementLeft of Speed), attacks left in an Attack action already taken.
public record CombatantData(
    Guid TokenId,
    string Kind,
    Guid? CharacterId,
    Guid? OwnerUserId,
    string Name,
    string ImageUrl,
    int Initiative,
    string? Health,
    bool Hidden,
    bool ActionUsed,
    bool BonusActionUsed,
    bool ReactionUsed,
    int MovementLeft,
    int Speed,
    int AttacksLeft);

// A made-up attack (an NPC's, a spell attack): Damage in dice notation ("1d6+2").
public record CustomAttackData(string Name, int Bonus, string Damage, string DamageType, int RangeFeet = 5);

public record AttackResultData(DiceRollData Attack, DiceRollData? Damage);
