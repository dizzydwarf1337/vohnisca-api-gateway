using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Card.GrantCampaignCardAccess;

public class GrantCampaignCardAccessCommand : UserRequest<Unit>
{
    public Guid CardId { get; set; }
    public Guid TargetUserId { get; set; }
}