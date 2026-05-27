using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.UpdateMemberRole;

public class UpdateMemberRoleCommand : UserRequest<Unit>
{
    public string CampaignId { get; set; }
    public string TargetUserId { get; set; }
    public required string Role { get; set; }
}