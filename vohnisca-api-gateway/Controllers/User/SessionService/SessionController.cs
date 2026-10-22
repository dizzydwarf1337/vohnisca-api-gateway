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
using Application.Commands.User.Session.CastSpell;
using Application.Commands.User.Session.SetShortRest;
using Application.Commands.User.Session.TakeLongRest;
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
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

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

    // ---- Scene (the map) ----

    [HttpGet]
    [Route("sessions/{id:guid}/scene")]
    public Task<IActionResult> GetScene(Guid id)
        => HandleResponse(new GetSceneQuery { SessionId = id });

    // Multipart: name, cols, rows, fog, and optionally "file" (the background image).
    [HttpPut]
    [Route("sessions/{id:guid}/scene")]
    public async Task<IActionResult> SetScene(Guid id, [FromForm] string? name, [FromForm] int cols, [FromForm] int rows,
        [FromForm] bool fog, [FromForm] IFormFile? file)
    {
        var (bytes, contentType) = await GetFileContent.GetAsync(
            file, [FileType.ImageJpeg, FileType.ImagePng, FileType.ImageWebp, FileType.ImageGif]);

        return await HandleResponse(new SetSceneCommand
        {
            SessionId = id,
            Name = name ?? string.Empty,
            Cols = cols,
            Rows = rows,
            Fog = fog,
            Image = bytes,
            ImageContentType = contentType,
        });
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/fog")]
    public Task<IActionResult> SetSceneFog(Guid id, SetSceneFogCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/reveal")]
    public Task<IActionResult> RevealSceneCells(Guid id, RevealSceneCellsCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/tokens")]
    public Task<IActionResult> AddSceneToken(Guid id, AddSceneTokenCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}")]
    public Task<IActionResult> UpdateSceneToken(Guid id, Guid tokenId, UpdateSceneTokenCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}")]
    public Task<IActionResult> RemoveSceneToken(Guid id, Guid tokenId)
        => HandleResponse(new RemoveSceneTokenCommand { SessionId = id, TokenId = tokenId });

    [HttpPost]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}/move")]
    public Task<IActionResult> MoveSceneToken(Guid id, Guid tokenId, MoveSceneTokenCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    // ---- Dice ----

    [HttpGet]
    [Route("sessions/{id:guid}/dice")]
    public Task<IActionResult> GetDiceRolls(Guid id)
        => HandleResponse(new GetDiceRollsQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/dice")]
    public Task<IActionResult> RollDice(Guid id, RollDiceCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/cast")]
    public Task<IActionResult> CastSpell(Guid id, Guid characterId, CastSpellCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/rest/short")]
    public Task<IActionResult> SetShortRest(Guid id, SetShortRestCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/rest/long")]
    public Task<IActionResult> TakeLongRest(Guid id)
        => HandleResponse(new TakeLongRestCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/checks")]
    public Task<IActionResult> RollCheck(Guid id, Guid characterId, RollCheckCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    // ---- Combat ----

    [HttpGet]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> GetEncounter(Guid id)
        => HandleResponse(new GetEncounterQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> StartCombat(Guid id, StartCombatCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> EndCombat(Guid id)
        => HandleResponse(new EndCombatCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat/join")]
    public Task<IActionResult> JoinCombat(Guid id, JoinCombatCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/combat/end-turn")]
    public Task<IActionResult> EndTurn(Guid id)
        => HandleResponse(new EndTurnCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat/attack")]
    public Task<IActionResult> Attack(Guid id, AttackCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}")]
    public Task<IActionResult> RemoveCombatant(Guid id, Guid tokenId)
        => HandleResponse(new RemoveCombatantCommand { SessionId = id, TokenId = tokenId });

    [HttpPut]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/initiative")]
    public Task<IActionResult> SetInitiative(Guid id, Guid tokenId, SetInitiativeCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/spent")]
    public Task<IActionResult> SetSpent(Guid id, Guid tokenId, SetSpentCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/dash")]
    public Task<IActionResult> Dash(Guid id, Guid tokenId)
        => HandleResponse(new DashCommand { SessionId = id, TokenId = tokenId });
}
