using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetNpcVisibility;

public class SetNpcVisibilityCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public string Visibility { get; set; } = "Private";
}
