using Application.Commands.User.Session.GatherSpill;
using Application.Commands.User.Session.IgniteSceneTerrain;
using Application.Commands.User.Session.SetSceneWalls;
using Application.Queries.User.Session.GetSpellInfo;
using Application.Queries.User.Session.GetItemInfo;
using Application.Commands.User.Session.SetLongRest;
using Application.Commands.User.Session.EquipSessionItem;
using Application.Commands.User.Session.UnequipSessionItem;
using Application.Commands.User.Session.DropItem;
using Application.Commands.User.Session.PickUpItem;
using Application.Commands.User.Session.UseItem;
using Application.Commands.User.Session.ThrowItem;
using Application.Commands.User.Session.AddSceneTerrain;
using Application.Commands.User.Session.UpdateSceneTerrain;
using Application.Commands.User.Session.RemoveSceneTerrain;
using Application.Queries.User.Session.GetEncounter;
using Application.Commands.User.Session.CastSpell;
using Application.Commands.User.Session.SetShortRest;
using Application.Commands.User.Session.TakeLongRest;
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
using Application.Commands.User.Session.RemoveSceneArea;
using Application.Commands.User.Session.TakeCombatAction;
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
    Task<RpcResult<SessionData>> SetShortRest(SetShortRestCommand request, string token);
    Task<RpcResult<SessionData>> SetLongRest(SetLongRestCommand request, string token);
    Task<RpcResult<SessionData>> EquipSessionItem(EquipSessionItemCommand request, string token);
    Task<RpcResult<SessionData>> UnequipSessionItem(UnequipSessionItemCommand request, string token);
    Task<RpcResult<SessionData>> DropItem(DropItemCommand request, string token);
    Task<RpcResult<SessionData>> PickUpItem(PickUpItemCommand request, string token);
    Task<RpcResult<CombatResultData>> UseItem(UseItemCommand request, string token);
    Task<RpcResult<CombatResultData>> ThrowItem(ThrowItemCommand request, string token);
    Task<RpcResult<SessionSceneData>> AddSceneTerrain(AddSceneTerrainCommand request, string token);
    Task<RpcResult<SessionSceneData>> UpdateSceneTerrain(UpdateSceneTerrainCommand request, string token);
    Task<RpcResult<SessionSceneData>> RemoveSceneTerrain(RemoveSceneTerrainCommand request, string token);
    Task<RpcResult<SessionData>> TakeLongRest(TakeLongRestCommand request, string token);
    Task<RpcResult<CombatResultData>> CastSpell(CastSpellCommand request, string token);

    Task<RpcResult<SessionSceneData>> GetScene(GetSceneQuery request, string token);
    Task<RpcResult<SessionData>> GatherSpill(GatherSpillCommand request, string token);
    Task<RpcResult<SessionSceneData>> IgniteSceneTerrain(IgniteSceneTerrainCommand request, string token);
    Task<RpcResult<SessionSceneData>> SetSceneWalls(SetSceneWallsCommand request, string token);
    Task<RpcResult<SpellInfoData>> GetSpellInfo(GetSpellInfoQuery request, string token);
    Task<RpcResult<ItemInfoData>> GetItemInfo(GetItemInfoQuery request, string token);
    Task<RpcResult<SessionSceneData>> SetScene(SetSceneCommand request, string token);
    Task<RpcResult<SessionSceneData>> SetSceneFog(SetSceneFogCommand request, string token);
    Task<RpcResult<SessionSceneData>> RevealSceneCells(RevealSceneCellsCommand request, string token);
    Task<RpcResult<SessionSceneData>> AddSceneToken(AddSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> UpdateSceneToken(UpdateSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> RemoveSceneToken(RemoveSceneTokenCommand request, string token);
    Task<RpcResult<SessionSceneData>> RemoveSceneArea(RemoveSceneAreaCommand request, string token);
    Task<RpcResult<CombatResultData>> TakeCombatAction(TakeCombatActionCommand request, string token);
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
    Task<RpcResult<CombatResultData>> Attack(AttackCommand request, string token);
}

// The session as the user may see it. Status: "lobby" | "live"; ShortRest: the GM called
// one. Enum values (conditions, resources, dice) come as camelCase names.
public record SessionData(
    Guid Id,
    Guid CampaignId,
    string CampaignTitle,
    Guid GmUserId,
    string GmName,
    string Status,
    DateTime OpenedAt,
    DateTime? StartedAt,
    bool ShortRest,
    // The GM called a long rest: players change their prepared spells until it ends.
    bool LongRest,
    List<SessionPlayerData> Players,
    List<SessionLogData> Log);

// Character: the whole sheet in play (the user's own, or every one for the GM); Member:
// what the table sees of it.
public record SessionPlayerData(Guid UserId, string Username, bool Ready, SessionCharacterData? Character, SessionMemberData? Member);

public record SessionMemberData(
    Guid Id,
    string Name,
    string AvatarUrl,
    int Level,
    string Classes,
    int MaxHitPoints,
    int CurrentHitPoints,
    int TemporaryHitPoints,
    bool IsDead,
    List<string> Conditions,
    string? Concentration,
    List<string> Effects);

// Kind "combat": what an attack or a spell did (Text may run over several lines).
public record SessionLogData(DateTime At, Guid UserId, Guid? CharacterId, string Text, string? Kind);

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
    int? SpellAttackBonus,
    List<InventoryRowData> Inventory,
    // Only during a long rest: the spells each class may prepare.
    List<PrepClassData>? Preparation);

// What a character carries. Kind: "weapon" | "armor" | "shield" | "gear"; Slot: where it's
// worn ("mainHand", "offHand", "armor", "shield", "accessory"; null in the pack); Throw: what
// throwing it does ("acid", "fire", "holy", "net", "oil", "caltrops", "bearings"; "item": it
// just lands; null: a weapon thrown with an attack); Use: "heal" (a Potion of Healing).
public record InventoryRowData(
    Guid ItemId, string Name, string Kind, int Quantity, string? Slot, bool Light, bool TwoHanded, bool Wearable,
    string? Throw, int ThrowRange, string? Use);

// Rule: "all" (change any), "one" (replace one this rest), "levelUp" (changes on a level up).
public record PrepClassData(Guid ClassId, string ClassName, string Rule, int Max, int Prepared, List<PrepSpellData> Spells);

public record PrepSpellData(Guid Id, string Name, int Level, string School, bool Prepared, bool Concentration, bool Ritual);

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

// Effect: what the spell does to its targets (null when casting only spends what it costs).
public record SessionSpellData(
    Guid Id,
    string Name,
    int Level,
    bool Ritual,
    bool Concentration,
    int? FreeUsesLeft,
    bool RitualOnly,
    string CastingTime,
    string Range,
    SpellEffectData? Effect);

// A spell's mechanics at its own level for the character (a cantrip grown with its level):
// Attack "melee" | "ranged"; Save: the ability; Damage / Healing in dice notation (+ the
// spellcasting modifier when AddsModifier); DamageChoices: types the caster picks from
// when DamageType is null; Projectiles: darts, rays or beams, each picking a target
// (ProjectilePerSlot more per higher slot); Upcast: added per higher slot.
public record SpellEffectData(
    string? Attack,
    string? Save,
    bool HalfOnSave,
    string? Damage,
    string? DamageType,
    List<string> DamageChoices,
    string? Healing,
    bool AddsModifier,
    int Projectiles,
    bool ProjectilePerSlot,
    string? Upcast,
    string? OnFailedSave,
    int? RangeFeet,
    bool Lasting,
    SpellAreaData? Area,
    bool AreaStays,
    // Its caster picks creatures it leaves alone (Spirit Guardians).
    bool Spares,
    // It brings the dead back (Revivify), or makes the dying Stable (Spare the Dying).
    bool Revives,
    bool Stabilizes);

// The area a spell fills: Shape "sphere" | "cylinder" | "cone" | "cube" | "line" |
// "emanation"; Size: radius, length or side in feet; Width: a line's; FromCaster: it
// starts at the caster (otherwise it's placed at a point in range).
public record SpellAreaData(string Shape, int Size, int Width, bool FromCaster);

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
    List<SceneTokenData> Tokens,
    List<SceneAreaData> Areas,
    List<SceneTerrainData> Terrain,
    // Wall squares as [col, row] (nobody walks into them).
    List<int[]> Walls);

// Terrain the GM painted or something spilled: squares as [col, row]; Hidden: a trap (the
// GM only); FromItem: spilled (Caltrops, Ball Bearings).
// Fuel: poured oil, not lit; Gatherable: spilled Caltrops or Ball Bearings; BurnsOut: it
// burns for a few rounds.
public record SceneTerrainData(
    Guid Id, string Name, string Color, List<int[]> Cells, ZoneEffectData Effect, bool Hidden, bool FromItem, bool Fuel, bool Gatherable, bool BurnsOut);

// What a zone does to a creature in it: when (entering, the start or the end of its turn
// there), its save and DC, damage (dice and type; half on a save if HalfOnSave), a
// condition on a failure, Difficult Terrain, Stops (a failure ends its move), damage for
// every 5 feet moved through it. Abilities, damage types, conditions lower-case.
public record ZoneEffectData(
    bool OnEnter = false, bool OnStartTurn = false, bool OnEndTurn = false, string? Save = null, int? Dc = null, string? Damage = null,
    string? DamageType = null, bool HalfOnSave = false, string? Condition = null, bool Difficult = false, bool Stops = false, bool PerFiveFeet = false);

// A spell's area that stays on the map (everyone sees it): Origin is where the caster
// stood when it was cast; an emanation follows CasterTokenId.
public record SceneAreaData(
    Guid Id,
    string Name,
    string Shape,
    int Size,
    int Width,
    bool FromCaster,
    double AimCol,
    double AimRow,
    int OriginCol,
    int OriginRow,
    int OriginSize,
    string Color,
    Guid? CasterTokenId,
    ZoneEffectData? Effect);

// Kind: "character" | "npc" | "item" | "marker"; OwnerUserId: the player of a character token.
// An NPC's numbers (MaxHp, Hp, Ac, Speed, InitiativeBonus) come to the GM; its Health and
// Conditions to everyone; its Sheet to the GM, and to players while SheetShown.
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
    string? Health,
    List<string> Conditions,
    bool SheetShown,
    TokenSheetData? Sheet);

// An NPC's sheet: saving throw bonuses, damage resistances / immunities /
// vulnerabilities, condition immunities, and what lasts on it (spells, the GM's notes).
public record TokenSheetData(
    Dictionary<string, int> Saves,
    List<string> Resistances,
    List<string> Immunities,
    List<string> Vulnerabilities,
    List<string> ConditionImmunities,
    List<string> Effects,
    List<NpcAttackData> Attacks);

// An NPC's attack the GM keeps on it: to hit, damage dice ("1d6+2"), type, reach or range.
public record NpcAttackData(Guid Id, string Name, int Bonus, string Damage, string DamageType, int RangeFeet);

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
    int AttacksLeft,
    bool Dodging,
    bool Disengaged,
    bool Assisted,
    bool Hiding,
    // It attacked with its main-hand weapon this turn: the off-hand attack may follow.
    bool OffHandReady);

// An NPC's attack made up by the GM: Damage in dice notation ("1d6+2").
public record CustomAttackData(string Name, int Bonus, string Damage, string DamageType, int RangeFeet = 5);

// What an attack or a spell did, as the user may read it (the same goes to the log).
public record CombatResultData(List<string> Log);

// A spell's details: the SRD text and what it does at the table (Effect: for the character
// asked about — its cantrip damage; SaveDc / AttackBonus its own); Classes: whose lists have
// it; From: how the character has it (prepared as a Wizard, granted by a feat...).
public record SpellInfoData(
    Guid Id, string Name, int Level, string School, string CastingTime, string Range, string Components, string Duration,
    bool Concentration, bool Ritual, string Description, string AtHigherLevels, string Source, List<string> Classes,
    List<string> From, SpellEffectData? Effect, int? SaveDc, int? AttackBonus);

// An item's details: Kind "weapon" | "armor" | "shield" | "gear"; Damage, Range,
// Properties, Mastery for a weapon; ArmorClass, StrengthNeeded, StealthDisadvantage for
// armor; Magic: what makes it more than mundane; Throw / Use: what they do at the table.
public record ItemInfoData(
    Guid Id, string Name, string Kind, string? Category, string Rarity, double Weight, string Value, string Description, string Source,
    string? Damage, string? Range, List<string> Properties, string? Mastery, string? ArmorClass, int? StrengthNeeded, bool StealthDisadvantage,
    List<string> Magic, string? Throw, string? Use);
