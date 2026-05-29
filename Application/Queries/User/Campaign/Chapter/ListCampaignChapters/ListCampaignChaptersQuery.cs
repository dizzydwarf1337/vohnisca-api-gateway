using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Chapter.ListCampaignChapters;

public class ListCampaignChaptersQuery : UserRequest<List<ChapterData>>
{
    public required string CampaignId { get; set; }
}