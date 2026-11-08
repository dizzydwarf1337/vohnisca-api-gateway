using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Discussion.GetUnreadCounts;

// Unread messages of the reader: the campaign's own forum, each chapter's forum, and the sum. Drives the
// badges on the chapter cards and on the discussion tabs.
public class GetUnreadCountsQuery : UserRequest<UnreadCountsResponse>
{
    public Guid CampaignId { get; set; }
}