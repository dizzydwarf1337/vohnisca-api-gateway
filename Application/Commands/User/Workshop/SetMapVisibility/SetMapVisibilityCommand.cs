using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetMapVisibility;

public class SetMapVisibilityCommand : UserRequest<bool>
{
    public Guid MapId { get; set; }
    public string Visibility { get; set; } = "Private";
}
