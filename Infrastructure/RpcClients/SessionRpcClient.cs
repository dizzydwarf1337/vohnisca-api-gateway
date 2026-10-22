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
}
