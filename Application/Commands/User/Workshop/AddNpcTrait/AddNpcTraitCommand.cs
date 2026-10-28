using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.AddNpcTrait;

public class AddNpcTraitCommand : UserRequest<NpcTraitAdded>
{
    public Guid NpcId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
