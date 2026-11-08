using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardVisibility;

public class SetCampaignCardVisibilityCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public bool IsPublic { get; set; }
}