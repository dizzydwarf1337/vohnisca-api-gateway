using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.DeleteItem;

public class DeleteWorkshopItemCommand : UserRequest<bool>
{
    public Guid ItemId { get; set; }
}
