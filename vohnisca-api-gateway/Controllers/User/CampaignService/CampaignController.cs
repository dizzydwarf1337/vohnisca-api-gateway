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

        return await HandleResponse(new GetCampaignQuery { CampaignId = id.ToString() });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCampaign(Guid id, UpdateCampaignCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id.ToString();

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCampaign(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteCampaignCommand { CampaignId = id.ToString() });
    }

    [HttpGet]
    [Route("{id:guid}/members")]
    public Task<IActionResult> ListMembers(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new ListMembersQuery { CampaignId = id.ToString() });
    }

    [HttpPost]
    [Route("{id:guid}/members")]
    public async Task<IActionResult> AddMember(Guid id, AddMemberCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();
        command.CampaignId = id.ToString();

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}/members/{targetUserId:guid}")]
    public async Task<IActionResult> RemoveMember(Guid id, Guid targetUserId)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty)
            return BadRequest();
        return await HandleResponse(new RemoveMemberCommand
            { CampaignId = id.ToString(), TargetUserId = targetUserId.ToString() });
    }

    [HttpPut]
    [Route("{id:guid}/members/{targetUserId:guid}/role")]
    public async Task<IActionResult> UpdateMemberRole(Guid id, Guid targetUserId, UpdateMemberRoleCommand command)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id.ToString();
        command.TargetUserId = targetUserId.ToString();

        return await HandleResponse(command);
    }
}