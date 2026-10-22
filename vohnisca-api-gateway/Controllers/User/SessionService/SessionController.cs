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
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.SessionService;

// Game sessions of a campaign. Live updates come over the session hub (/hubs/session,
// proxied to the session service).
[Route("")]
public class SessionController : BaseController
{
    [HttpGet]
    [Route("campaigns/{campaignId:guid}/session")]
    public Task<IActionResult> GetCampaignSession(Guid campaignId)
        => HandleResponse(new GetCampaignSessionQuery { CampaignId = campaignId });

    [HttpPost]
    [Route("campaigns/{campaignId:guid}/session")]
    public Task<IActionResult> OpenSession(Guid campaignId)
        => HandleResponse(new OpenSessionCommand { CampaignId = campaignId });

    [HttpGet]
    [Route("sessions/my")]
    public Task<IActionResult> ListMySessions()
        => HandleResponse(new ListMySessionsQuery());

    [HttpGet]
    [Route("sessions/{id:guid}")]
    public Task<IActionResult> GetSession(Guid id)
        => HandleResponse(new GetSessionQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/join")]
    public Task<IActionResult> JoinSession(Guid id, JoinSessionCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/leave")]
    public Task<IActionResult> LeaveSession(Guid id)
        => HandleResponse(new LeaveSessionCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/ready")]
    public Task<IActionResult> SetSessionReady(Guid id, SetSessionReadyCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/start")]
    public Task<IActionResult> StartSession(Guid id)
        => HandleResponse(new StartSessionCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/actions")]
    public Task<IActionResult> ApplySessionAction(Guid id, Guid characterId, ApplySessionActionCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/end")]
    public Task<IActionResult> EndSession(Guid id, EndSessionCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }
}
