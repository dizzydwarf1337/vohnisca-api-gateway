using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Scene.RevealSceneCard;

// Showing a scene to the players is the shared visibility layer (is_public) of stage 00, not a field of the
// scene kind; the answer carries the card as the service projects it for the caller.
public class RevealSceneCardCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public bool IsPublic { get; set; }
}