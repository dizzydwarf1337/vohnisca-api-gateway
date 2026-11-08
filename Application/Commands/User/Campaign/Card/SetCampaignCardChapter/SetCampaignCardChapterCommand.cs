using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardChapter;

public class SetCampaignCardChapterCommand : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
    public Guid? ChapterId { get; set; }
}
