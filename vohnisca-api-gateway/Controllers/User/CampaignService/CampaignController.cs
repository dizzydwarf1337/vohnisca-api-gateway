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
    public Task<IActionResult> CreateCampaign(CreateCampaignCommand command)
        => HandleResponse(command);

    [HttpPost("my")]
    public Task<IActionResult> ListMyCampaigns([FromBody] ListMyCampaignsQuery query)
        => HandleResponse(query);

    [HttpGet("{id}")]
    public Task<IActionResult> GetCampaign(string id)
        => HandleResponse(new GetCampaignQuery { CampaignId = id });

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateCampaign(string id, UpdateCampaignCommand command)
    {
        command.CampaignId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteCampaign(string id)
        => HandleResponse(new DeleteCampaignCommand { CampaignId = id });

    [HttpGet("{id}/members")]
    public Task<IActionResult> ListMembers(string id)
        => HandleResponse(new ListMembersQuery { CampaignId = id });

    [HttpPost("{id}/members")]
    public Task<IActionResult> AddMember(string id, AddMemberCommand command)
    {
        command.CampaignId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}/members/{targetUserId}")]
    public Task<IActionResult> RemoveMember(string id, string targetUserId)
        => HandleResponse(new RemoveMemberCommand { CampaignId = id, TargetUserId = targetUserId });

    [HttpPut("{id}/members/{targetUserId}/role")]
    public Task<IActionResult> UpdateMemberRole(string id, string targetUserId, UpdateMemberRoleCommand command)
    {
        command.CampaignId = id;
        command.TargetUserId = targetUserId;
        return HandleResponse(command);
    }
}