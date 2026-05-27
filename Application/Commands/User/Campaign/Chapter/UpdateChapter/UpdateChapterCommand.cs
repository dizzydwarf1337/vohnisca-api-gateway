using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Chapter.UpdateChapter;

public class UpdateChapterCommand : UserRequest<ChapterData>
{
    public string ChapterId { get; set; } = string.Empty;
    public required string Title { get; set; }
    public string? Content { get; set; }
}