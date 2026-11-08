using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Card.ListItemCards;

// The item cards as a tree: a container comes with its contents in Children. Asking for a containerId
// returns the cards inside that container (their own Children are empty, the depth is two).
public class ListItemCardsQuery : UserRequest<List<CampaignCardData>>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public Guid? ContainerId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}