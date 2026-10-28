using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.DeleteNpc;

public class DeleteNpcCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
}
