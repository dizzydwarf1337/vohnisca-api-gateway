using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.RemoveMember;

public class RemoveMemberCommand : UserRequest<Unit>
{
    public string CampaignId { get; set; }
    public string TargetUserId { get; set; }
}