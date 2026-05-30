using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Chapter.SetChapterVisibility;

public class SetChapterVisibilityCommand : UserRequest<ChapterData>
{
    public Guid ChapterId { get; set; }
    public bool IsVisibleToAll { get; set; }
}