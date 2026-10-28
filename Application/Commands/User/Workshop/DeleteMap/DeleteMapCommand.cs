using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.DeleteMap;

public class DeleteMapCommand : UserRequest<bool>
{
    public Guid MapId { get; set; }
}
