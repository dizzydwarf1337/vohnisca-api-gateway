using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Catalog.GetItemInfo;

// An item's details for a window.
public class GetItemInfoQuery : UserRequest<CatalogItemInfo>
{
    public Guid ItemId { get; set; }
}
