using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Chapter.CreateChapter;

public class CreateChapterCommand : UserRequest<ChapterData>
{
    public Guid CampaignId { get; set; }
    public Guid? ParentId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}