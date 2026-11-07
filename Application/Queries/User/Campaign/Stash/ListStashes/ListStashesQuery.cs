using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Stash.ListStashes;

// Every stash of a campaign (a camp, a cart, a hiding place): each carries its own coins and contents.
public class ListStashesQuery : UserRequest<List<StashData>>
{
    public Guid CampaignId { get; set; }
}