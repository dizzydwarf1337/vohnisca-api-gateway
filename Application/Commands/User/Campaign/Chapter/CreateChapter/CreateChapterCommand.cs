using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Chapter.CreateChapter;

public class CreateChapterCommand : UserRequest<ChapterData>
{
    public required string CampaignId { get; set; }
    public string? ParentId { get; set; }
    public required string Title { get; set; }
    public string? Content { get; set; }
}