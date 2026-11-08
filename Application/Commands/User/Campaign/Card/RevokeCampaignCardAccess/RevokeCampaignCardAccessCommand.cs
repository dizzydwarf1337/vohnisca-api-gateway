using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Card.RevokeCampaignCardAccess;

public class RevokeCampaignCardAccessCommand : UserRequest<Unit>
{
    public Guid CardId { get; set; }
    public Guid TargetUserId { get; set; }
}