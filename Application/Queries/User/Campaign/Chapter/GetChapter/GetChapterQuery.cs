using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Chapter.GetChapter;

public class GetChapterQuery : UserRequest<ChapterData>
{
    public Guid ChapterId { get; set; }
}