using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.RemoveMember;

public class RemoveMemberCommand : UserRequest<Unit>
{
    public Guid CampaignId { get; set; }
    public Guid TargetUserId { get; set; }
}