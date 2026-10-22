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
using Application.Interfaces.RpcClients;
using Application.Queries.User.Session.GetCampaignSession;
using Application.Queries.User.Session.GetSession;
using Application.Queries.User.Session.ListMySessions;
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

    public Task<RpcResult<SessionSceneData>> SetScene(SetSceneCommand request, string token)
        => SendData<SessionSceneData>("SetScene", request, token);

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

    public Task<RpcResult<AttackResultData>> Attack(AttackCommand request, string token)
        => SendData<AttackResultData>("Attack", request, token);
}
