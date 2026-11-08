using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Discussion.SetThreadHidden;

// Hiding a thread takes it off the players' list entirely — the service filters it, no client-side styling.
public class SetThreadHiddenCommand : UserRequest<ThreadData>
{
    public Guid ThreadId { get; set; }
    public bool IsHidden { get; set; }
}