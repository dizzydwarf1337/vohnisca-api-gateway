using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.History.ListCampaignHistory;

// The campaign journal, newest first: filters by operation kind, by who did it, and by a period of days.
public class ListCampaignHistoryQuery : UserRequest<List<HistoryEntryData>>
{
    public Guid CampaignId { get; set; }
    public string? Kind { get; set; }
    public Guid? ActorId { get; set; }
    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}