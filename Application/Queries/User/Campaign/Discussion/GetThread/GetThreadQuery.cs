using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Discussion.GetThread;

// The thread screen in one answer: the topic and a window of its latest messages.
public class GetThreadQuery : UserRequest<ThreadViewResponse>
{
    public Guid ThreadId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}