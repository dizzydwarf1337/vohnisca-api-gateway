using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetItemById;

public class GetItemByIdQuery : UserRequest<ItemDetail>
{
    public Guid Id { get; set; }
}
