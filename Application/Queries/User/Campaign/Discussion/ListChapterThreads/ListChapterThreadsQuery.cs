using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Discussion.ListChapterThreads;

// The forum of one chapter. The route carries only the chapter, so the handler asks the chapter for its
// campaign first: the campaign service keys every thread by campaign and takes no thread list without it.
public class ListChapterThreadsQuery : UserRequest<List<ThreadData>>
{
    public Guid ChapterId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}