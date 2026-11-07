using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.SetThreadLocked;

// A locked thread takes no new messages; reading it stays open. The service is the one that enforces it.
public class SetThreadLockedCommand : UserRequest<ThreadData>
{
    public Guid ThreadId { get; set; }
    public bool IsLocked { get; set; }
}