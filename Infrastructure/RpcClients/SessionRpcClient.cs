using Application.Commands.User.Session.SetBreakableWalls;
using Application.Commands.User.Session.SetWallPiece;
using Application.Commands.User.Session.SetObjectToughness;
using Application.Commands.User.Session.SetTimeScale;
using Application.Commands.User.Session.PassTime;
using Application.Commands.User.Session.TimeCondition;
using Application.Commands.User.Session.CancelTimer;
using Application.Commands.User.Session.SetSceneVision;
using Application.Commands.User.Session.SetVisionGroups;
using Application.Commands.User.Session.SetTokenLight;
using Application.Commands.User.Session.PlaceSceneDoor;
using Application.Commands.User.Session.SetSceneLock;
using Application.Commands.User.Session.SetContainerContents;
using Application.Commands.User.Session.UseDoor;
using Application.Commands.User.Session.OpenContainer;
using Application.Commands.User.Session.TakeFromContainer;
using Application.Commands.User.Session.PutIntoContainer;
using Application.Commands.User.Session.UnlockLock;
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
using Application.Commands.User.Session.StartCombat;
using Application.Commands.User.Session.JoinCombat;
using Application.Commands.User.Session.RemoveCombatant;
using Application.Commands.User.Session.SetInitiative;
using Application.Commands.User.Session.EndTurn;
using Application.Commands.User.Session.EndCombat;
using Application.Commands.User.Session.SetSpent;
using Application.Commands.User.Session.Dash;
using Application.Commands.User.Session.AnswerReaction;
using Application.Commands.User.Session.AnnounceSpell;
using Application.Commands.User.Session.Attack;
using Application.Commands.User.Session.CastSpell;
using Application.Commands.User.Session.SetShortRest;
using Application.Commands.User.Session.TakeLongRest;
using Application.Queries.User.Session.GetDiceRolls;
using Application.Commands.User.Session.RollDice;
using Application.Commands.User.Session.RollCheck;
using Application.Queries.User.Session.GetScene;
using Application.Commands.User.Session.SetScene;
using Application.Commands.User.Session.LoadMapLevel;
using Application.Commands.User.Session.SaveSceneToMap;
using Application.Commands.User.Session.PlaceWorkshopNpc;
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
using Application.Interfaces.RpcClients;
using Application.Queries.User.Session.GetCampaignSession;
using Application.Queries.User.Session.GetSession;
using Application.Queries.User.Session.ListMySessions;
using Application.Queries.User.Session.GetSessionDashboard;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

// The session service lives in the character service's repository and speaks the same
// JSON-RPC (parameters under "request", results in an RpcResponse envelope).
public class SessionRpcClient : DotnetRpcClient, ISessionRpcClient
{
    public SessionRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:SessionService"] ?? throw new Exception("SessionService URI not set")) { }

    public Task<RpcResult<SessionData>> OpenSession(OpenSessionCommand request, string token)
        => SendData<SessionData>("OpenSession", request, token);

    public Task<RpcResult<CampaignSessionData>> GetCampaignSession(GetCampaignSessionQuery request, string token)
        => SendData<CampaignSessionData>("GetCampaignSession", request, token);

    public Task<RpcResult<SessionData>> GetSession(GetSessionQuery request, string token)
        => SendData<SessionData>("GetSession", request, token);

    public Task<RpcResult<List<SessionNoticeData>>> ListMySessions(ListMySessionsQuery request, string token)
        => SendData<List<SessionNoticeData>>("ListMySessions", request, token);

    public Task<RpcResult<SessionDashboardData>> GetSessionDashboard(GetSessionDashboardQuery request, string token)
        => SendData<SessionDashboardData>("GetSessionDashboard", request, token);

    public Task<RpcResult<SessionData>> JoinSession(JoinSessionCommand request, string token)
        => SendData<SessionData>("JoinSession", request, token);

    public Task<RpcResult<SessionData>> LeaveSession(LeaveSessionCommand request, string token)
        => SendData<SessionData>("LeaveSession", request, token);

    public Task<RpcResult<SessionData>> SetSessionReady(SetSessionReadyCommand request, string token)
        => SendData<SessionData>("SetSessionReady", request, token);

    public Task<RpcResult<SessionData>> StartSession(StartSessionCommand request, string token)
        => SendData<SessionData>("StartSession", request, token);

    // The action goes as its JSON text (the RPC client doesn't serialize a JsonElement).
    public Task<RpcResult<SessionData>> ApplySessionAction(ApplySessionActionCommand request, string token)
        => SendData<SessionData>("ApplySessionAction",
            new { request.SessionId, request.CharacterId, Action = request.Action.GetRawText() }, token);

    public Task<RpcResult<bool>> EndSession(EndSessionCommand request, string token)
        => SendData<bool>("EndSession", request, token);

    public Task<RpcResult<SessionSceneData>> GetScene(GetSceneQuery request, string token)
        => SendData<SessionSceneData>("GetScene", request, token);

    public Task<RpcResult<SessionData>> GatherSpill(GatherSpillCommand request, string token)
        => SendData<SessionData>("GatherSpill", request, token);

    public Task<RpcResult<SessionSceneData>> IgniteSceneTerrain(IgniteSceneTerrainCommand request, string token)
        => SendData<SessionSceneData>("IgniteSceneTerrain", request, token);

    public Task<RpcResult<SessionSceneData>> SetSceneWalls(SetSceneWallsCommand request, string token)
        => SendData<SessionSceneData>("SetSceneWalls", request, token);

    public Task<RpcResult<SpellInfoData>> GetSpellInfo(GetSpellInfoQuery request, string token)
        => SendData<SpellInfoData>("GetSpellInfo", request, token);

    public Task<RpcResult<ItemInfoData>> GetItemInfo(GetItemInfoQuery request, string token)
        => SendData<ItemInfoData>("GetItemInfo", request, token);

    public Task<RpcResult<SessionSceneData>> SetScene(SetSceneCommand request, string token)
        => SendData<SessionSceneData>("SetScene", request, token);

    public Task<RpcResult<SessionSceneData>> LoadMapLevel(LoadMapLevelCommand request, string token)
        => SendData<SessionSceneData>("LoadMapLevel", request, token);

    public Task<RpcResult<SessionSceneData>> SaveSceneToMap(SaveSceneToMapCommand request, string token)
        => SendData<SessionSceneData>("SaveSceneToMap", request, token);

    public Task<RpcResult<SessionSceneData>> PlaceWorkshopNpc(PlaceWorkshopNpcCommand request, string token)
        => SendData<SessionSceneData>("PlaceWorkshopNpc", request, token);

    public Task<RpcResult<SessionSceneData>> SetSceneFog(SetSceneFogCommand request, string token)
        => SendData<SessionSceneData>("SetSceneFog", request, token);

    public Task<RpcResult<SessionSceneData>> RevealSceneCells(RevealSceneCellsCommand request, string token)
        => SendData<SessionSceneData>("RevealSceneCells", request, token);

    public Task<RpcResult<SessionSceneData>> AddSceneToken(AddSceneTokenCommand request, string token)
        => SendData<SessionSceneData>("AddSceneToken", request, token);

    public Task<RpcResult<SessionSceneData>> UpdateSceneToken(UpdateSceneTokenCommand request, string token)
        => SendData<SessionSceneData>("UpdateSceneToken", request, token);

    public Task<RpcResult<SessionSceneData>> RemoveSceneToken(RemoveSceneTokenCommand request, string token)
        => SendData<SessionSceneData>("RemoveSceneToken", request, token);

    public Task<RpcResult<SessionSceneData>> RemoveSceneArea(RemoveSceneAreaCommand request, string token)
        => SendData<SessionSceneData>("RemoveSceneArea", request, token);

    public Task<RpcResult<SessionData>> SetLongRest(SetLongRestCommand request, string token)
        => SendData<SessionData>("SetLongRest", request, token);

    public Task<RpcResult<SessionData>> EquipSessionItem(EquipSessionItemCommand request, string token)
        => SendData<SessionData>("EquipItem", request, token);

    public Task<RpcResult<SessionData>> UnequipSessionItem(UnequipSessionItemCommand request, string token)
        => SendData<SessionData>("UnequipItem", request, token);

    public Task<RpcResult<SessionData>> DropItem(DropItemCommand request, string token)
        => SendData<SessionData>("DropItem", request, token);

    public Task<RpcResult<SessionData>> PickUpItem(PickUpItemCommand request, string token)
        => SendData<SessionData>("PickUpItem", request, token);

    public Task<RpcResult<SessionSceneData>> SetSceneVision(SetSceneVisionCommand request, string token)
        => SendData<SessionSceneData>("SetSceneVision", request, token);

    public Task<RpcResult<SessionData>> SetVisionGroups(SetVisionGroupsCommand request, string token)
        => SendData<SessionData>("SetVisionGroups", request, token);

    public Task<RpcResult<SessionData>> SetTimeScale(SetTimeScaleCommand request, string token)
        => SendData<SessionData>("SetTimeScale", request, token);

    public Task<RpcResult<SessionData>> PassTime(PassTimeCommand request, string token)
        => SendData<SessionData>("PassTime", request, token);

    public Task<RpcResult<SessionData>> TimeCondition(TimeConditionCommand request, string token)
        => SendData<SessionData>("TimeCondition", request, token);

    public Task<RpcResult<SessionData>> CancelTimer(CancelTimerCommand request, string token)
        => SendData<SessionData>("CancelTimer", request, token);

    public Task<RpcResult<SessionSceneData>> SetTokenLight(SetTokenLightCommand request, string token)
        => SendData<SessionSceneData>("SetTokenLight", request, token);

    public Task<RpcResult<SessionSceneData>> PlaceSceneDoor(PlaceSceneDoorCommand request, string token)
        => SendData<SessionSceneData>("PlaceSceneDoor", request, token);

    public Task<RpcResult<SessionSceneData>> SetBreakableWalls(SetBreakableWallsCommand request, string token)
        => SendData<SessionSceneData>("SetBreakableWalls", request, token);

    public Task<RpcResult<SessionSceneData>> SetWallPiece(SetWallPieceCommand request, string token)
        => SendData<SessionSceneData>("SetWallPiece", request, token);

    public Task<RpcResult<SessionSceneData>> SetObjectToughness(SetObjectToughnessCommand request, string token)
        => SendData<SessionSceneData>("SetObjectToughness", request, token);

    public Task<RpcResult<SessionSceneData>> SetSceneLock(SetSceneLockCommand request, string token)
        => SendData<SessionSceneData>("SetSceneLock", request, token);

    public Task<RpcResult<SessionSceneData>> SetContainerContents(SetContainerContentsCommand request, string token)
        => SendData<SessionSceneData>("SetContainerContents", request, token);

    public Task<RpcResult<SessionData>> UseDoor(UseDoorCommand request, string token)
        => SendData<SessionData>("UseDoor", request, token);

    public Task<RpcResult<SessionData>> OpenContainer(OpenContainerCommand request, string token)
        => SendData<SessionData>("OpenContainer", request, token);

    public Task<RpcResult<SessionData>> TakeFromContainer(TakeFromContainerCommand request, string token)
        => SendData<SessionData>("TakeFromContainer", request, token);

    public Task<RpcResult<SessionData>> PutIntoContainer(PutIntoContainerCommand request, string token)
        => SendData<SessionData>("PutIntoContainer", request, token);

    public Task<RpcResult<CombatResultData>> UnlockLock(UnlockLockCommand request, string token)
        => SendData<CombatResultData>("UnlockLock", request, token);

    public Task<RpcResult<CombatResultData>> UseItem(UseItemCommand request, string token)
        => SendData<CombatResultData>("UseItem", request, token);

    public Task<RpcResult<CombatResultData>> ThrowItem(ThrowItemCommand request, string token)
        => SendData<CombatResultData>("ThrowItem", request, token);

    public Task<RpcResult<SessionSceneData>> AddSceneTerrain(AddSceneTerrainCommand request, string token)
        => SendData<SessionSceneData>("AddSceneTerrain", request, token);

    public Task<RpcResult<SessionSceneData>> UpdateSceneTerrain(UpdateSceneTerrainCommand request, string token)
        => SendData<SessionSceneData>("UpdateSceneTerrain", request, token);

    public Task<RpcResult<SessionSceneData>> RemoveSceneTerrain(RemoveSceneTerrainCommand request, string token)
        => SendData<SessionSceneData>("RemoveSceneTerrain", request, token);

    public Task<RpcResult<CombatResultData>> TakeCombatAction(TakeCombatActionCommand request, string token)
        => SendData<CombatResultData>("TakeCombatAction", request, token);

    public Task<RpcResult<SessionSceneData>> MoveSceneToken(MoveSceneTokenCommand request, string token)
        => SendData<SessionSceneData>("MoveSceneToken", request, token);

    public Task<RpcResult<DiceRollsData>> GetDiceRolls(GetDiceRollsQuery request, string token)
        => SendData<DiceRollsData>("GetDiceRolls", request, token);

    public Task<RpcResult<DiceRollData>> RollDice(RollDiceCommand request, string token)
        => SendData<DiceRollData>("RollDice", request, token);

    public Task<RpcResult<DiceRollData>> RollCheck(RollCheckCommand request, string token)
        => SendData<DiceRollData>("RollCheck", request, token);

    public Task<RpcResult<SessionEncounterData>> GetEncounter(GetEncounterQuery request, string token)
        => SendData<SessionEncounterData>("GetEncounter", request, token);

    public Task<RpcResult<SessionEncounterData>> StartCombat(StartCombatCommand request, string token)
        => SendData<SessionEncounterData>("StartCombat", request, token);

    public Task<RpcResult<SessionEncounterData>> JoinCombat(JoinCombatCommand request, string token)
        => SendData<SessionEncounterData>("JoinCombat", request, token);

    public Task<RpcResult<SessionEncounterData>> RemoveCombatant(RemoveCombatantCommand request, string token)
        => SendData<SessionEncounterData>("RemoveCombatant", request, token);

    public Task<RpcResult<SessionEncounterData>> SetInitiative(SetInitiativeCommand request, string token)
        => SendData<SessionEncounterData>("SetInitiative", request, token);

    public Task<RpcResult<SessionEncounterData>> EndTurn(EndTurnCommand request, string token)
        => SendData<SessionEncounterData>("EndTurn", request, token);

    public Task<RpcResult<bool>> EndCombat(EndCombatCommand request, string token)
        => SendData<bool>("EndCombat", request, token);

    public Task<RpcResult<SessionEncounterData>> SetSpent(SetSpentCommand request, string token)
        => SendData<SessionEncounterData>("SetSpent", request, token);

    public Task<RpcResult<SessionEncounterData>> Dash(DashCommand request, string token)
        => SendData<SessionEncounterData>("Dash", request, token);

    public Task<RpcResult<CombatResultData>> Attack(AttackCommand request, string token)
        => SendData<CombatResultData>("Attack", request, token);

    public Task<RpcResult<CombatResultData>> AnswerReaction(AnswerReactionCommand request, string token)
        => SendData<CombatResultData>("AnswerReaction", request, token);

    public Task<RpcResult<CombatResultData>> AnnounceSpell(AnnounceSpellCommand request, string token)
        => SendData<CombatResultData>("AnnounceSpell", request, token);

    public Task<RpcResult<CombatResultData>> CastSpell(CastSpellCommand request, string token)
        => SendData<CombatResultData>("CastSpell", request, token);

    public Task<RpcResult<SessionData>> SetShortRest(SetShortRestCommand request, string token)
        => SendData<SessionData>("SetShortRest", request, token);

    public Task<RpcResult<SessionData>> TakeLongRest(TakeLongRestCommand request, string token)
        => SendData<SessionData>("TakeLongRest", request, token);
}
