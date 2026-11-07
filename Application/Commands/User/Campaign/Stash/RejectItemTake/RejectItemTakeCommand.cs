using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.RejectItemTake;

public class RejectItemTakeCommand : UserRequest<ItemRequestData>
{
    public Guid RequestId { get; set; }
}