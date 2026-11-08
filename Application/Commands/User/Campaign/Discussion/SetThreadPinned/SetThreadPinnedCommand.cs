using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.SetThreadPinned;

// A game master's flag: a pinned thread rises to the top of the forum.
public class SetThreadPinnedCommand : UserRequest<ThreadData>
{
    public Guid ThreadId { get; set; }
    public bool IsPinned { get; set; }
}