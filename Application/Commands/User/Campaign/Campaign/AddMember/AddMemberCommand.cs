using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.AddMember;

public class AddMemberCommand : UserRequest<Unit>
{
    public Guid CampaignId { get; set; }
    public Guid TargetUserId { get; set; }
    public string Role { get; set; }
}