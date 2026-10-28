using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.RemoveNpcTrait;

public class RemoveNpcTraitCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public Guid TraitId { get; set; }
}
