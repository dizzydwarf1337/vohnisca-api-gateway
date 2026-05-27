using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.AddMember;

public class AddMemberCommand : UserRequest<Unit>
{
    public string CampaignId { get; set; }
    public required string TargetUserId { get; set; }
    public required string Role { get; set; }
}