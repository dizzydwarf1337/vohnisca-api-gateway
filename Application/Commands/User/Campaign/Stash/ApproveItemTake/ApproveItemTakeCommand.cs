using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Stash.ApproveItemTake;

public class ApproveItemTakeCommand : UserRequest<ItemRequestData>
{
    public Guid RequestId { get; set; }
}