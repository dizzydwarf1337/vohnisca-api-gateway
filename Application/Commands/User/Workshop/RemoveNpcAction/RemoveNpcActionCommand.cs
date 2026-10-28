using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.RemoveNpcAction;

public class RemoveNpcActionCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public Guid ActionId { get; set; }
}
