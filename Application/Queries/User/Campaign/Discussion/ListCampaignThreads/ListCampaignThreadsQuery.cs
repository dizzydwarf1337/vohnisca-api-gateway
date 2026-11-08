using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Discussion.ListCampaignThreads;

// The campaign's own forum (chapterId left out) or the forum of one chapter: pinned first, then by the last
// message — the campaign service decides the order and what the reader may see.
public class ListCampaignThreadsQuery : UserRequest<List<ThreadData>>
{
    public Guid CampaignId { get; set; }
    public Guid? ChapterId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}