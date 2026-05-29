using Application.Commands.User.Campaign.Campaign.AddMember;
using Application.Commands.User.Campaign.Campaign.CreateCampaign;
using Application.Commands.User.Campaign.Campaign.DeleteCampaign;
using Application.Commands.User.Campaign.Campaign.RemoveMember;
using Application.Commands.User.Campaign.Campaign.UpdateCampaign;
using Application.Commands.User.Campaign.Campaign.UpdateMemberRole;
using Application.Queries.User.Campaign.Campaign.GetCampaign;
using Application.Queries.User.Campaign.Campaign.ListMembers;
using Application.Queries.User.Campaign.Campaign.ListMyCampaigns;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

[Route("campaigns")]
public class CampaignController : BaseController
{
    [HttpPost("")]
    public Task<IActionResult> CreateCampaign(CreateCampaignCommand? command)
    {
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(command);
    }

    [HttpPost("my")]
    public Task<IActionResult> ListMyCampaigns([FromBody] ListMyCampaignsQuery? query)
    {
        if (query is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(query);
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetCampaign(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new GetCampaignQuery { CampaignId = id.ToString() });
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateCampaign(Guid id, UpdateCampaignCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.CampaignId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteCampaign(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new DeleteCampaignCommand { CampaignId = id.ToString() });
    }

    [HttpGet("{id:guid}/members")]
    public Task<IActionResult> ListMembers(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new ListMembersQuery { CampaignId = id.ToString() });
    }

    [HttpPost("{id:guid}/members")]
    public Task<IActionResult> AddMember(Guid id, AddMemberCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.CampaignId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/members/{targetUserId}")]
    public Task<IActionResult> RemoveMember(Guid id, string targetUserId)
    {
        if (id == Guid.Empty || string.IsNullOrEmpty(targetUserId))
            return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new RemoveMemberCommand { CampaignId = id.ToString(), TargetUserId = targetUserId });
    }

    [HttpPut("{id:guid}/members/{targetUserId}/role")]
    public Task<IActionResult> UpdateMemberRole(Guid id, string targetUserId, UpdateMemberRoleCommand? command)
    {
        if (id == Guid.Empty || string.IsNullOrEmpty(targetUserId))
            return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.CampaignId = id.ToString();
        command.TargetUserId = targetUserId;
        return HandleResponse(command);
    }
}