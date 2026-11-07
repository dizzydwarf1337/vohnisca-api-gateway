using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Card.ListCampaignCards;

public class ListCampaignCardsQuery : UserRequest<List<CampaignCardData>>
{
    public Guid CampaignId { get; set; }
    public string? Kind { get; set; }
    public Guid? ChapterId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}