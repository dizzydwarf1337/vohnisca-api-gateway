using Application.Commands.User.Campaign.Campaign.AddMember;
using Application.Commands.User.Campaign.Clock.AdvanceCampaignClock;
using Application.Commands.User.Campaign.Clock.ForceReleaseCampaignClock;
using Application.Queries.User.Campaign.Clock.GetCampaignClock;
using Application.Commands.User.Campaign.Campaign.CreateCampaign;
using Application.Commands.User.Campaign.Campaign.DeleteCampaign;
using Application.Commands.User.Campaign.Campaign.RemoveMember;
using Application.Commands.User.Campaign.Campaign.SetCampaignSessionSettings;
using Application.Commands.User.Campaign.Campaign.UpdateCampaign;
using Application.Commands.User.Campaign.Campaign.UpdateMemberRole;
using Application.Queries.User.Campaign.Campaign.GetCampaign;
using Application.Queries.User.Campaign.Campaign.ListMembers;
using Application.Queries.User.Campaign.Campaign.ListMyCampaigns;
using Application.Queries.User.Campaign.History.ListCampaignHistory;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

[Route("campaigns")]
public class CampaignController : BaseController
{
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateCampaign(CreateCampaignCommand command)
        => await HandleResponse(command);


    [HttpPost]
    [Route("my")]
    public async Task<IActionResult> ListMyCampaigns(ListMyCampaignsQuery query)
        => await HandleResponse(query);

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCampaign(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetCampaignQuery { CampaignId = id });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCampaign(Guid id, UpdateCampaignCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCampaign(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteCampaignCommand { CampaignId = id });
    }

    [HttpGet]
    [Route("{id:guid}/history")]
    public async Task<IActionResult> ListCampaignHistory(Guid id, [FromQuery] string? kind, [FromQuery] Guid? actorId,
        [FromQuery] DateOnly? from, [FromQuery] DateOnly? to, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListCampaignHistoryQuery
        {
            CampaignId = id,
            Kind = kind,
            ActorId = actorId,
            From = from,
            To = to,
            Page = page,
            PageSize = pageSize,
        });
    }

    [HttpGet]
    [Route("{id:guid}/members")]
    public Task<IActionResult> ListMembers(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new ListMembersQuery { CampaignId = id });
    }

    [HttpPost]
    [Route("{id:guid}/members")]
    public async Task<IActionResult> AddMember(Guid id, AddMemberCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();
        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}/members/{targetUserId:guid}")]
    public async Task<IActionResult> RemoveMember(Guid id, Guid targetUserId)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty)
            return BadRequest();
        return await HandleResponse(new RemoveMemberCommand
        { CampaignId = id, TargetUserId = targetUserId });
    }

    [HttpPut]
    [Route("{id:guid}/members/{targetUserId:guid}/role")]
    public async Task<IActionResult> UpdateMemberRole(Guid id, Guid targetUserId, UpdateMemberRoleCommand command)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;
        command.TargetUserId = targetUserId;

        return await HandleResponse(command);
    }

    // What the campaign's next session opens with (I-12).
    [HttpPut]
    [Route("{id:guid}/session-settings")]
    public async Task<IActionResult> SetCampaignSessionSettings(Guid id, SetCampaignSessionSettingsCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    // The campaign's game time (I-03): a session's table moves it while it holds it; out of a session, the GM.
    [HttpGet]
    [Route("{id:guid}/clock")]
    public async Task<IActionResult> GetCampaignClock(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetCampaignClockQuery { CampaignId = id });
    }

    [HttpPost]
    [Route("{id:guid}/clock/advance")]
    public async Task<IActionResult> AdvanceCampaignClock(Guid id, AdvanceCampaignClockCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/clock/release")]
    public async Task<IActionResult> ForceReleaseCampaignClock(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ForceReleaseCampaignClockCommand { CampaignId = id });
    }
}
